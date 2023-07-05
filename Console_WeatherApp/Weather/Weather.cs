using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Console_WeatherApp.Weather;

    public record Coord(
        [property: JsonPropertyName("lon")] double Lon,
        [property: JsonPropertyName("lat")] double Lat
    );

    public record WeatherInfo(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("main")] string Main,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("icon")] string Icon
    );

    public record Main(
        [property: JsonPropertyName("temp")] double Temp,
        [property: JsonPropertyName("feels_like")] double FeelsLike,
        [property: JsonPropertyName("temp_min")] double TempMin,
        [property: JsonPropertyName("temp_max")] double TempMax,
        [property: JsonPropertyName("pressure")] int Pressure,
        [property: JsonPropertyName("humidity")] int Humidity
    );

    public record Wind(
        [property: JsonPropertyName("speed")] double Speed,
        [property: JsonPropertyName("deg")] int Deg
    );

    public record Clouds(
        [property: JsonPropertyName("all")] int All
    );

    public record Sys(
        [property: JsonPropertyName("type")] int Type,
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("country")] string Country,
        [property: JsonPropertyName("sunrise")] long Sunrise,
        [property: JsonPropertyName("sunset")] long Sunset
    );

    public record Weather(
        [property: JsonPropertyName("coord")] Coord Coord,
        [property: JsonPropertyName("weather")] List<WeatherInfo> WeatherInfos,
        [property: JsonPropertyName("base")] string Base,
        [property: JsonPropertyName("main")] Main Main,
        [property: JsonPropertyName("visibility")] int Visibility,
        [property: JsonPropertyName("wind")] Wind Wind,
        [property: JsonPropertyName("clouds")] Clouds Clouds,
        [property: JsonPropertyName("dt")] long Dt,
        [property: JsonPropertyName("sys")] Sys Sys,
        [property: JsonPropertyName("timezone")] int Timezone,
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("cod")] int Cod
    );
