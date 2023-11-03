namespace BuildingBricks.Product.Models;

/// <summary>
/// Represents a product to be bought and sold.
/// </summary>
public class Merchandise : IModel
{

	/// <summary>
	/// Identifier of the merchandise record.
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// The name of the merchandise.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// Identifier of the primary theme for the merchandise.
	/// </summary>
	[JsonProperty("themeId")]
	public string ThemeId { get; set; } = null!;

	/// <summary>
	/// The name of the primary theme for the merchandise.
	/// </summary>
	[JsonProperty("themeName")]
	public string ThemeName { get; set; } = null!;

	/// <summary>
	/// The year the merchandise was released.
	/// </summary>
	[JsonProperty("yearReleased")]
	public int YearReleased { get; set; }

	/// <summary>
	/// The shipping weight of the merchandise.
	/// </summary>
	[JsonProperty("weight")]
	public int Weight { get; set; }

	/// <summary>
	/// The list price for the merchandise.
	/// </summary>
	[JsonProperty("price")]
	public decimal Price { get; set; }

	/// <summary>
	/// The number of pieces in the merchandise.
	/// </summary>
	[JsonProperty("pieces")]
	public int Pieces { get; set; }

	/// <summary>
	/// The number of VIP points awarded for purchasing the merchandise.
	/// </summary>
	[JsonProperty("vipPoints")]
	public int VIPPoints { get; set; }

	/// <summary>
	/// Flag indicating whether the merchandise is hard to find in the physical stores.
	/// </summary>
	[JsonProperty("hardToFind")]
	public bool HardToFind { get; set; }

	/// <summary>
	/// Identifier of the current availability for the merchandise.
	/// </summary>
	[JsonProperty("availabilityId")]
	public string AvailabilityId { get; set; } = null!;

	/// <summary>
	/// The name of the current availability for the merchandise.
	/// </summary>
	[JsonProperty("availability")]
	public string Availability { get; set; } = null!;

	/// <summary>
	/// The description for the merchandise.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; } = null!;

	/// <summary>
	/// The height of the built merchandise in centimeters.
	/// </summary>
	[JsonProperty("heightCentimeters")]
	public int HeightCentimeters { get; set; }

	/// <summary>
	/// The height of the built merchandise in inches.
	/// </summary>
	[JsonProperty("heightInches")]
	public decimal HeightInches { get; set; }

	/// <summary>
	/// The width of the built merchandise in centimeters.
	/// </summary>
	[JsonProperty("widthCentimeters")]
	public int WidthCentimeters { get; set; }

	/// <summary>
	/// The width of the built merchandise in inches.
	/// </summary>
	[JsonProperty("widthInches")]
	public decimal WidthInches { get; set; }

	/// <summary>
	/// The depth of the built merchandise in centimeters.
	/// </summary>
	[JsonProperty("depthCentimeters")]
	public int DepthCentimeters { get; set; }

	/// <summary>
	/// The depth of the built merchandise in inches.
	/// </summary>
	[JsonProperty("depthInches")]
	public decimal DepthInches { get; set; }

	/// <summary>
	/// Flag indicating whether the record has been marked as deleted.
	/// </summary>
	[JsonProperty("isDeleted")]
	public bool IsDeleted { get; set; }

	[JsonProperty("ttl")]
	public int TTL { get; set; } = -1;

}