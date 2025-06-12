namespace Libraries.Polly
{
    public static class AppHttpClient
    {
        public static async Task<HttpResponseMessage> GetAsync()
        {
            string url = DateTime.Now.Millisecond % 2 == 0 ? "https://httpstat.us/503" : "https://httpstat.us/200";
            using (var client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }
    }
}
