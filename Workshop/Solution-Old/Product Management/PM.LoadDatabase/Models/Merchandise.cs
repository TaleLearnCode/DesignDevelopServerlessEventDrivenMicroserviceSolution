namespace BuildingBricks.PM.Models;

public class Merchandise
{

	[JsonProperty("id")]
	public string Id { get; set; } = null!;

	[JsonProperty("name")]
	public string Name { get; set; } = null!;

	[JsonProperty("themeId")]
	public string ThemeId { get; set; } = null!;

	[JsonProperty("themeName")]
	public string ThemeName { get; set; } = null!;

	[JsonProperty("yearReleased")]
	public int YearReleased { get; set; }

	[JsonProperty("weight")]
	public int Weight { get; set; }

	[JsonProperty("price")]
	public decimal Price { get; set; }

	[JsonProperty("pieces")]
	public int Pieces { get; set; }

	[JsonProperty("vipPoints")]
	public int VIPPoints { get; set; }

	[JsonProperty("hardToFind")]
	public bool HardToFind { get; set; }

	[JsonProperty("availabilityId")]
	public string AvailabilityId { get; set; } = null!;

	[JsonProperty("availability")]
	public string Availability { get; set; } = null!;

	[JsonProperty("description")]
	public string Description { get; set; } = null!;

	[JsonProperty("heightCentimeters")]
	public int HeightCentimeters { get; set; }

	[JsonProperty("heightInches")]
	public decimal HeightInches { get; set; }

	[JsonProperty("widthCentimeters")]
	public int WidthCentimeters { get; set; }

	[JsonProperty("widthInches")]
	public decimal WidthInches { get; set; }

	[JsonProperty("depthCentimeters")]
	public int DepthCentimeters { get; set; }

	[JsonProperty("depthInches")]
	public decimal DepthInches { get; set; }

}