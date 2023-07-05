using Console_WeatherApp.ZipCode;
using Console_WeatherApp.Weather;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Enter API Key: ");
Environment.SetEnvironmentVariable ("WEATHER_APP_API_KEY", Console.ReadLine());
Console.Write("Enter Zipcide: ");
Environment.SetEnvironmentVariable("ZIPCODE", Console.ReadLine());

Console.WriteLine("Getting weather...");

var appid = Environment.GetEnvironmentVariable("WEATHER_APP_API_KEY");
var appZipCode = Environment.GetEnvironmentVariable("ZIPCODE");


ZipCodeData zipCodeData = new ZipCodeData();
ZipCodeDataResult zipCodeDataResult = await zipCodeData.ProcessZipCodeAsync($"https://api.openweathermap.org/geo/1.0/zip?zip={appZipCode}&appid={appid}");
try
{
    if (!zipCodeDataResult.Success)
    {
        Console.WriteLine($"Failed to retrieve zip code data: {zipCodeDataResult.ErrorMessage}");
    }
}
catch (Exception exception)
{
    Console.WriteLine($"An error occurred while logging zip codes: {exception.Message}");
}

WeatherData weatherData = new WeatherData();
WeatherDataResults weatherDataResults = await weatherData.ProcessWeatherAsync(
    $"https://api.openweathermap.org/data/2.5/weather?lat={zipCodeDataResult.ZipCode.Lat}&lon={zipCodeDataResult.ZipCode.Lon}&units=metric&appid={appid}");
try
{
    if (weatherDataResults.Success)
    {
        Console.Clear();
        Console.WriteLine($"(Zipcode:{zipCodeDataResult.ZipCode.Zip}) Current weather in {weatherDataResults.Weather.Name} is {weatherDataResults.Weather.Main.Temp}C");
    }
    else
    {
        Console.WriteLine($"Failed to retrieve zip code data: {weatherDataResults.ErrorMessage}");
    } 
}
catch(Exception exception)
{
    Console.WriteLine($"An error occurred while logging zip codes: {exception.Message}");
}


static void LogZipCodes(ZipCode zipData)
{
    Console.WriteLine($"Name: {zipData.Name}");
    Console.WriteLine($"ZipCode: {zipData.Zip}");
    Console.WriteLine($"Latitude: {zipData.Lat}");
    Console.WriteLine($"Longitude: {zipData.Lon}");
    Console.WriteLine($"Country: {zipData.Country}");
}