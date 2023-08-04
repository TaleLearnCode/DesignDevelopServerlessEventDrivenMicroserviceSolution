namespace BuildingBricks.PM.Models;

public abstract class Metadata
{

  [JsonProperty("id")]
  public string Id { get; set; } = null!;

  [JsonProperty("legacyId")]
  public int LegacyId { get; set; }

  [JsonProperty("metadataType")]
  public string MetadataType { get; set; } = null!;

}