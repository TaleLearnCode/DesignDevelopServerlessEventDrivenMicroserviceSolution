
namespace BuildingBricks.Product.Services;

public class MerchandiseServices : ServicesBase<Merchandise>
{

	private const string _queryText = $"SELECT * FROM merchandise";

	public MerchandiseServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, configServices.ProductMerchandiseContainerId) { }

	public MerchandiseServices(ConfigServices configServices, Database database) : base(database, configServices.ProductMerchandiseContainerId) { }

	public MerchandiseServices(Container container) : base(container) { }

	public async Task<Merchandise> GetAsync(string id) => await GetAsync(id, id);

	public async Task<List<Merchandise>> GetListAsync() => await GetListAsync(_queryText);

	public async Task<List<Merchandise>> GetListByAvailabilityAsync(string availabilityId) => await GetListAsync($"{_queryText} WHERE c.availability > 0 AND c.availabilityId = '{availabilityId}'");

	public async Task<Merchandise> AddAsync(Merchandise item) => await AddAsync(item, item.Id, false);

	public async Task<Merchandise> ReplaceAsync(Merchandise item) => await ReplaceAsync(item, item.Id);

	public async Task<Merchandise> UpsertAsync(Merchandise item) => await UpsertAsync(item, item.Id);

	public async Task<bool> DeleteAsync(Merchandise item)
	{
		item.TTL = 60 * 60 * 2;
		await ReplaceAsync(item, item.Id);
		return true;
	}

}