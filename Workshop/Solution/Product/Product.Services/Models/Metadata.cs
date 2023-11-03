namespace BuildingBricks.Product.Models;

/// <summary>
/// Base class for entities representing product metadata.
/// </summary>
public abstract class Metadata : IMetadata
{

	protected Metadata(string metadataType) => MetadataType = metadataType;

	/// <summary>
	/// Identifier for the metadata record.
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// The legacy identifier for the metadata record.
	/// </summary>
	[JsonProperty("legacyId")]
	public int LegacyId { get; set; }

	/// <summary>
	/// The type of metadata being represented.
	/// </summary>
	[JsonProperty("metadataType")]
	public string MetadataType { get; set; }

}