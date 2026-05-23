using System.Net;
using System.Text;

namespace ServerHTTPApp;
public class Program
{
    static async Task Main(string[] args)
    {
        using HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        Console.WriteLine("Server is running...");

        using var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };

        try
        {
            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();

                _ = Task.Run(() => HandleRequestAsync(context));
            }
        }
        catch (HttpListenerException ex) when (cts.Token.IsCancellationRequested)
        {
            // Ignore
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
    private static async Task HandleRequestAsync(HttpListenerContext context)
    {
        try
        {
            Console.WriteLine($"New request: {context.Request.Url}");
            string responseStr = "<h1>Hello World</h1>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseStr);
            using HttpListenerResponse response = context.Response;
            response.ContentLength64 = buffer.Length;
            response.ContentType = "text/html; charset=utf-8";

            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
