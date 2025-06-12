using Polly;
using Polly.Retry;
using Polly.Timeout;

namespace Libraries.Polly;

internal class Program
{
    static async Task Main(string[] args)
    {
        var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
            .AddRetry(new RetryStrategyOptions<HttpResponseMessage>
            {
                MaxRetryAttempts = 3,
                Delay = TimeSpan.FromSeconds(2),
                ShouldHandle = new PredicateBuilder<HttpResponseMessage>().HandleResult(response =>
                {
                    Console.WriteLine($"Handling response: {response.StatusCode}");
                    return !response.IsSuccessStatusCode;
                })
            })
            .AddTimeout(new TimeoutStrategyOptions
            {
                Timeout = TimeSpan.FromSeconds(5)
            })
            .Build();

        for (int i = 0; i < 20; i++)
        {
            try
            {
                var response = await pipeline.ExecuteAsync(async token => 
                { 
                    Console.WriteLine($"Executing request {i + 1} at {DateTime.Now}");
                    return await AppHttpClient.GetAsync(); 
                });
                Console.WriteLine($"Response received: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }
    }
}
