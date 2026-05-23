namespace ClienHTTPApp;
public class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();
        try
        {
            HttpResponseMessage response = await client.GetAsync("https://example.com");

            response.EnsureSuccessStatusCode();

            await PrintResponseDataAsync(response);
        }
        catch (Exception)
		{

			throw;
		}
    }

    private static async Task PrintResponseDataAsync(HttpResponseMessage response)
    {
        Console.WriteLine(" ============ HTTP RESPONSE ============ ");

        Console.WriteLine("Status:");
        Console.WriteLine($"{(int)response.StatusCode} {response.ReasonPhrase} HTTP/{response.Version}");

        Console.WriteLine("Headers: ");
        foreach (var header in response.Headers)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }
        Console.WriteLine("Body: ");
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }
}
