using System.Net;

namespace BuildingBricks.Product.Services;

public abstract class ServicesBase<T> where T : class, IModel
{

	protected readonly Container _container;

	protected ServicesBase(ConfigServices configServices, CosmosClient cosmosClient, string containerId)
		=> _container = cosmosClient.GetDatabase(configServices.ProductCosmosDatabaseId).GetContainer(containerId);

	protected ServicesBase(Database database, string containerId)
		=> _container = database.GetContainer(containerId);

	protected ServicesBase(Container container)
		=> _container = container;

	protected async Task<T> GetAsync(string id, string partitionKeyValue) => await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKeyValue));

	protected async Task<List<T>> GetListAsync(string queryText)
	{
		List<T> response = new();
		using FeedIterator<T> feed = _container.GetItemQueryIterator<T>(queryText);
		while (feed.HasMoreResults)
		{
			FeedResponse<T> feedResponse = await feed.ReadNextAsync();
			foreach (T item in feedResponse)
				response.Add(item);
		}
		return response;
	}

	protected async Task<T> AddAsync(T item, string partitionKeyValue, bool overrideId = true)
	{
		ArgumentNullException.ThrowIfNull(item);
		if (overrideId) item.Id = Guid.NewGuid().ToString();
		T createdItem = await _container.CreateItemAsync<T>(item, new PartitionKey(partitionKeyValue));
		return createdItem;
	}

	protected async Task<T> UpsertAsync(T item, string partitionKeyValue)
	{
		ArgumentNullException.ThrowIfNull(item);
		ItemResponse<T> itemResponse = await _container.UpsertItemAsync<T>(item, new PartitionKey(partitionKeyValue));
		return itemResponse.Resource;
	}

	protected async Task<T> ReplaceAsync(T item, string partitionKeyValue)
	{
		ArgumentNullException.ThrowIfNull(item);
		ItemResponse<T> itemResponse = await _container.ReplaceItemAsync<T>(item, item.Id, new PartitionKey(partitionKeyValue));
		return itemResponse.Resource;
	}

	protected async Task<bool> DeleteAsync(T item, string partitionKeyValue)
	{
		ArgumentNullException.ThrowIfNull(item);
		ItemResponse<T> itemResponse = await _container.DeleteItemAsync<T>(item.Id, new PartitionKey(partitionKeyValue));
		return itemResponse.StatusCode == HttpStatusCode.OK;
	}

}