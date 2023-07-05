
namespace Console_WeatherApp.Weather;

public class WeatherDataResults
{
    public Weather Weather { get; set; }
    public bool Success { get; set; }
    
    public string ErrorMessage { get; set; }
}