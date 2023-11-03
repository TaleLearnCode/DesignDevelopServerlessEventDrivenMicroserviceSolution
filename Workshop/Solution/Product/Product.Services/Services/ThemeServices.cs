using BuildingBricks.Product.Constants;

namespace BuildingBricks.Product.Services;

public class ThemeServices : MetadataServicesBase<Theme>
{

	public ThemeServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, Constants.MetadataType.Theme) { }

	public ThemeServices(ConfigServices configServices, Database database) : base(configServices, database, Constants.MetadataType.Theme) { }

	public ThemeServices(ConfigServices configServices, Container container) : base(configServices, container, Constants.MetadataType.Theme) { }

	public async Task<Theme> GetAsync(string id) => await GetMetadataAsync(id);

	public async Task<List<Theme>> GetListAsync()
	{
		List<Theme> response = new();
		using FeedIterator<Theme> feed = _container.GetItemQueryIterator<Theme>("SELECT * FROM metadata");
		while (feed.HasMoreResults)
		{
			FeedResponse<Theme> feedResponse = await feed.ReadNextAsync();
			foreach (Theme item in feedResponse)
				if (item.MetadataType == MetadataType.Theme)
					response.Add(item);
		}
		return response;
	}

	public async Task<Dictionary<int, Theme>> GetDictionaryAsync() => (await GetListAsync()).ToDictionary(x => x.LegacyId, x => x);

	public async Task<Theme> AddAsync(Theme item, bool overrideId = true) => await AddMetadataAsync(item, overrideId);

	public async Task<Theme> ReplaceAsync(Theme item) => await ReplaceMetadataAsync(item);

	public async Task<Theme> UpsertAsync(Theme item) => await UpsertMetadataAsync(item);

	public async Task<bool> DeleteAsync(Theme item) => await DeleteMetadataAsync(item);

}