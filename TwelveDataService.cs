namespace FinancialDataWeb
{
    public class TwelveDataService
    {
        public HttpClient _client { get; set; }

        public  TwelveDataService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.twelvedata.com/");

            _client = client;   
        }
    }
}
