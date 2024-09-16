using CarStockAPI.Model;

namespace CarStockAPI.Data
{
    public interface IDealers
    {
        public Dealer RegisterDealer(string Id);

        public bool CheckExists(string Id);

        public bool CheckKey(string Key);

        public List<KeyValuePair<string,string>> GetAllAPIKeys();

        public string GetDealerId(string apiKey);
    }
}
