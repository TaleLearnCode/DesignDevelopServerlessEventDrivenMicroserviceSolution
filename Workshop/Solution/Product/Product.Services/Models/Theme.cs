namespace BuildingBricks.Product.Models;

/// <summary>
/// Represents a theme grouping similar merchandises.
/// </summary>
/// <seealso cref="Metadata"/>
public class Theme : Metadata
{

	public Theme() : base(Constants.MetadataType.Theme) { }

	/// <summary>
	/// The name of the merchandise.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// List of the merchandises that are part of the theme.
	/// </summary>
	[JsonProperty("merchandises")]
	public List<ThemeMerchandise> Merchandises { get; set; } = new();

}