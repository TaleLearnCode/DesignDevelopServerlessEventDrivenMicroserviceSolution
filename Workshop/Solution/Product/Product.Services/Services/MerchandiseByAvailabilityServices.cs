namespace BuildingBricks.Product.Services;

public class MerchandiseByAvailabilityServices : ServicesBase<Merchandise>
{

	public MerchandiseByAvailabilityServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, configServices.ProductsByAvailabilityContainerId) { }

	public MerchandiseByAvailabilityServices(ConfigServices configServices, Database database) : base(database, configServices.ProductsByAvailabilityContainerId) { }

	public MerchandiseByAvailabilityServices(ConfigServices configServices, Container container) : base(container) { }

	public async Task<List<Merchandise>> GetAsync(string availabilityId) => await GetListAsync($"SELECT * FROM merchandise WHERE availabilityId = '{availabilityId}'");

	public async Task<Dictionary<string, Merchandise>> GetDictionaryAsync() => (await GetListAsync("SELECT * FROM merchandise")).ToDictionary(x => x.AvailabilityId, x => x);

	public async Task<Merchandise> UpsertAsync(Merchandise item) => await UpsertAsync(item, item.AvailabilityId);

	public async Task<bool> DeleteAsync(Merchandise item) => await DeleteAsync(item, item.AvailabilityId);

}