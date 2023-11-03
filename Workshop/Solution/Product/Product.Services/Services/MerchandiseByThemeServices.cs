namespace BuildingBricks.Product.Services;

public class MerchandiseByThemeServices : ServicesBase<Merchandise>
{

	public MerchandiseByThemeServices(ConfigServices configServices, CosmosClient cosmosClient) : base(configServices, cosmosClient, configServices.ProductsByThemeContainerId) { }

	public MerchandiseByThemeServices(ConfigServices configServices, Database database) : base(database, configServices.ProductsByThemeContainerId) { }

	public MerchandiseByThemeServices(ConfigServices configServices, Container container) : base(container) { }

	public async Task<List<Merchandise>> GetAsync(string themeId) => await GetListAsync($"SELECT * FROM merchandise WHERE themeId = '{themeId}'");

	public async Task<Dictionary<string, Merchandise>> GetDictionaryAsync() => (await GetListAsync("SELECT * FROM merchandise")).ToDictionary(x => x.ThemeId, x => x);

	public async Task<Merchandise> UpsertAsync(Merchandise item) => await UpsertAsync(item, item.ThemeId);

	public async Task<bool> DeleteAsync(Merchandise item) => await DeleteAsync(item, item.ThemeId);

}