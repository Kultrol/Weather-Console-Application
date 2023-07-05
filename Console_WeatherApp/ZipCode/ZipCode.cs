using System.Text.Json.Serialization;

namespace Console_WeatherApp.ZipCode;

public record ZipCode(

    // Map the 'Name' property to the 'name' field in the JSON.
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("zip")] string Zip,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lon")] double Lon,
    [property: JsonPropertyName("country")] string Country
    
    );