namespace FinancialDataWeb.Api
{
    public interface IDataProcessor<T>
    {
        public Task<T> LoadData(string symbol, string interval);
    }
}
