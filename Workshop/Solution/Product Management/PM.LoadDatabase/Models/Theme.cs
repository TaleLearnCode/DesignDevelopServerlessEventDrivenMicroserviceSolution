namespace BuildingBricks.PM.Models;

public class Theme : Metadata
{

	[JsonProperty("name")]
	public string Name { get; set; } = null!;

	[JsonProperty("merchandises")]
	public List<ThemeMerchandise> Merchandises { get; set; } = new();

}