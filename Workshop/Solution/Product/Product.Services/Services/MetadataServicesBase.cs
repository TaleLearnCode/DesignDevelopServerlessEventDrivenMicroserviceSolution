namespace BuildingBricks.Product.Services;

public abstract class MetadataServicesBase<T> : ServicesBase<T> where T : Metadata
{

	private readonly string _partitionKeyValue;
	private readonly string _queryText;
	private readonly string _metadataType;

	protected MetadataServicesBase(
		ConfigServices configServices,
		CosmosClient cosmosClient,
		string metadataType) : base(configServices, cosmosClient, configServices.ProductMerchandiseContainerId)
	{
		_partitionKeyValue = metadataType;
		_metadataType = metadataType;
		//_queryText = $"SELECT * FROM metadata WHERE metadataType = '{metadataType}'";
		_queryText = $"SELECT * FROM metadata";
	}

	protected MetadataServicesBase(
		ConfigServices configServices,
		Database database,
		string metadataType) : base(database, configServices.ProductMerchandiseContainerId)
	{
		_partitionKeyValue = metadataType;
		_metadataType = metadataType;
		//_queryText = $"SELECT * FROM metadata WHERE metadataType = '{metadataType}'";
		_queryText = $"SELECT * FROM metadata";
	}

	protected MetadataServicesBase(
		ConfigServices configServices,
		Container container,
		string metadataType) : base(container)
	{
		_partitionKeyValue = metadataType;
		_metadataType = metadataType;
		//_queryText = $"SELECT * FROM metadata WHERE metadataType = '{metadataType}'";
		_queryText = $"SELECT * FROM metadata";
	}

	public async Task<T> GetMetadataAsync(string id) => await GetAsync(id, _partitionKeyValue);

	public async Task<T> AddMetadataAsync(T item, bool overrideId = true) => await AddAsync(item, _partitionKeyValue, overrideId);

	public async Task<T> ReplaceMetadataAsync(T item) => await ReplaceAsync(item, _partitionKeyValue);

	public async Task<T> UpsertMetadataAsync(T item) => await UpsertAsync(item, _partitionKeyValue);

	public async Task<bool> DeleteMetadataAsync(T item) => await DeleteAsync(item, _partitionKeyValue);

}