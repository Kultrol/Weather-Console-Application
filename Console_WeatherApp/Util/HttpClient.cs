using System.Net.Http;
namespace Console_WeatherApp.Util;

public class HttpClientCall
{
    private static readonly HttpClient PrivateClient; 

    static HttpClientCall()
    {
        PrivateClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) } ;
    }

    public static HttpClient Client => PrivateClient;
    
    public static void CustomizeClient(Action<HttpClient> action)
    {
        action(PrivateClient);
    }

}