namespace Console_WeatherApp.ZipCode;

public class ZipCodeDataResult
{
    public ZipCode ZipCode { get; set; }
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
}