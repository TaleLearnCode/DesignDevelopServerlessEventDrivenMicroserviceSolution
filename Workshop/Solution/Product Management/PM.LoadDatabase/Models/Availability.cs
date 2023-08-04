namespace BuildingBricks.PM.Models;

public class Availability : Metadata
{

  [JsonProperty("name")]
  public string Name { get; set; } = null!;

}