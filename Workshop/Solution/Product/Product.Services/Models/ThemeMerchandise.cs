namespace BuildingBricks.Product.Models;

/// <summary>
/// Represents a merchandise with its theme information.
/// </summary>
public class ThemeMerchandise
{

	/// <summary>
	/// The item number for the merchandise.
	/// </summary>
	[JsonProperty("itemNumber")]
	public string ItemNumber { get; set; } = null!;

	/// <summary>
	/// The name of the merchandise item.
	/// </summary>
	[JsonProperty("itemName")]
	public string ItemName { get; set; } = null!;

	/// <summary>
	/// The number of pieces in the merchandise.
	/// </summary>
	[JsonProperty("pieces")]
	public int Pieces { get; set; }

	/// <summary>
	/// The list price for the merchandise.
	/// </summary>
	[JsonProperty("price")]
	public decimal Price { get; set; }

	/// <summary>
	/// Flag indicating whether the merchandise is hard to find in the physical stores.
	/// </summary>
	[JsonProperty("hardToFind")]
	public bool HardToFind { get; set; }

	/// <summary>
	/// Identifier of the merchandise's current availability status.
	/// </summary>
	[JsonProperty("availabilityId")]
	public string AvailabilityId { get; set; } = null!;

	/// <summary>
	/// Name of the merchandise's current availability status.
	/// </summary>
	[JsonProperty("availability")]
	public string Availability { get; set; } = null!;

}