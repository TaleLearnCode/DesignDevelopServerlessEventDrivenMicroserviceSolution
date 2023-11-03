namespace BuildingBricks.Product.Models;

public interface IMetadata : IModel
{
	public int LegacyId { get; set; }
	public string MetadataType { get; set; }
}