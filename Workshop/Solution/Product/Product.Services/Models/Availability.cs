namespace BuildingBricks.Product.Models;

/// <summary>
/// Represents the availability of a product.
/// </summary>
public class Availability : Metadata
{

	public Availability() : base(Constants.MetadataType.Availability) { }

	/// <summary>
	/// The name of the product availability.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; } = null!;

}