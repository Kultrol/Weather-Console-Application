using System.Text.Json;
using Console_WeatherApp.Util;

namespace Console_WeatherApp.Weather;

public class WeatherData
{
    public async Task<WeatherDataResults> ProcessWeatherAsync(string url, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(url))
        {
            return new WeatherDataResults { Success = false, ErrorMessage = "URL cannot be null or empty." };
        }

        try
        {
            HttpResponseMessage response = await HttpClientCall.Client.GetAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                var weather = await JsonSerializer.DeserializeAsync<Weather>(stream);
                return new WeatherDataResults { Weather = weather, Success = true };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new WeatherDataResults
                    { Success = false, ErrorMessage = "Error 401: Unauthorized - Invalid API key." };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new WeatherDataResults
                    { Success = false, ErrorMessage = "Error 4040: Not Found - Invalid request." };
            }
            else
            {
                return new WeatherDataResults
                    { Success = false, ErrorMessage = $"Error {(int)response.StatusCode}: {response.ReasonPhrase}" };
            }
        }
        catch (HttpRequestException requestException)
        {
            return new WeatherDataResults
                { Success = false, ErrorMessage = $"Request error: {requestException.Message}" };
        }
        catch (JsonException jsonException)
        {
            return new WeatherDataResults
                { Success = false, ErrorMessage = $"JSON parsing error: {jsonException.Message}" };
        }
        catch (Exception exception)
        {
            return new WeatherDataResults
                { Success = false, ErrorMessage = $"An unexpected error occured: {exception.Message}" };
        }
    }
    
}