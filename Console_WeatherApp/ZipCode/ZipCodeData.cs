using System.Text.Json;
using Console_WeatherApp.Util;

namespace Console_WeatherApp.ZipCode;

public class ZipCodeData
{
    public async Task<ZipCodeDataResult> ProcessZipCodeAsync(string url, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(url))
        {
            return new ZipCodeDataResult { Success = false, ErrorMessage = "URL cannot be null or empty." };
        }

        try
        {
            HttpResponseMessage response = await HttpClientCall.Client.GetAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                var zipcode = await JsonSerializer.DeserializeAsync<ZipCode>(stream, cancellationToken: cancellationToken);
                return new ZipCodeDataResult { ZipCode = zipcode, Success = true };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new ZipCodeDataResult { Success = false, ErrorMessage = "Error 401: Unauthorized - Invalid API key." };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ZipCodeDataResult { Success = false, ErrorMessage = "Error 404: Not Found - Invalid request." };
            }
            else
            {
                return new ZipCodeDataResult { Success = false, ErrorMessage = $"Error {(int)response.StatusCode}: {response.ReasonPhrase}" };
            }
        }
        catch (HttpRequestException ex)
        {
            return new ZipCodeDataResult { Success = false, ErrorMessage = $"Request error: {ex.Message}" };
        }
        catch (JsonException ex)
        {
            return new ZipCodeDataResult { Success = false, ErrorMessage = $"JSON parsing error: {ex.Message}" };
        }
        catch (Exception ex)
        {
            return new ZipCodeDataResult { Success = false, ErrorMessage = $"An unexpected error occurred: {ex.Message}" };
        }
    }
}