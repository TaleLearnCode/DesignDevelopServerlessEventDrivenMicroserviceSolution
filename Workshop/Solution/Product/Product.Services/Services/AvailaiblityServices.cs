using BuildingBricks.Product.Constants;

namespace BuildingBricks.Product.Services;

public class AvailabilityServices : MetadataServicesBase<Availability>
{

	public AvailabilityServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, MetadataType.Availability) { }

	public AvailabilityServices(ConfigServices configServices, Database database) : base(configServices, database, MetadataType.Availability) { }

	public AvailabilityServices(ConfigServices configServices, Container container) : base(configServices, container, MetadataType.Availability) { }

	public async Task<Availability> GetAsync(string id) => await GetMetadataAsync(id);

	public async Task<List<Availability>> GetListAsync()
	{
		List<Availability> response = new();
		using FeedIterator<Availability> feed = _container.GetItemQueryIterator<Availability>("SELECT * FROM metadata");
		while (feed.HasMoreResults)
		{
			FeedResponse<Availability> feedResponse = await feed.ReadNextAsync();
			foreach (Availability item in feedResponse)
				if (item.MetadataType == MetadataType.Availability)
					response.Add(item);
		}
		return response;
	}

	public async Task<Dictionary<int, Availability>> GetDictionaryAsync() => (await GetListAsync()).ToDictionary(x => x.LegacyId, x => x);

	public async Task<Availability> AddAsync(Availability item, bool overrideId = true) => await AddMetadataAsync(item, overrideId);

	public async Task<Availability> ReplaceAsync(Availability item) => await ReplaceMetadataAsync(item);

	public async Task<Availability> UpsertAsync(Availability item) => await UpsertMetadataAsync(item);

	public async Task<bool> DeleteAsync(Availability item) => await DeleteMetadataAsync(item);

}