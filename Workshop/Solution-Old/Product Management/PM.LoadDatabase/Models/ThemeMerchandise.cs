namespace BuildingBricks.PM.Models;

#nullable disable

public class ThemeMerchandise
{

	[JsonProperty("itemNumber")]
	public string ItemNumber { get; set; } = null!;

	[JsonProperty("itemName")]
	public string ItemName { get; set; } = null!;

	[JsonProperty("pieces")]
	public int Pieces { get; set; }

	[JsonProperty("price")]
	public decimal Price { get; set; }

	[JsonProperty("hardToFind")]
	public bool HardToFind { get; set; }

	[JsonProperty("availabilityId")]
	public string AvailabilityId { get; set; }

	[JsonProperty("availability")]
	public string Availability { get; set; } = null!;

}