namespace FinancialDataWeb.Api
{
    public class DataProcessor : IDataProcessor<Root>
    {
        public async Task<Root> LoadData(string symbol, string interval)
        {
            string url = "";
            string api_key = "&apikey=4ea1eb1f53bc4c11add8877c115c10cd";

            if (!symbol.Equals(""))
            {
                url = $"https://api.twelvedata.com/time_series?symbol={symbol}&interval={interval}{api_key}";

            }
            else
            {


            }
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(data);
                    return root;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
