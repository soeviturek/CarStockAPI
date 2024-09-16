using CarStockAPI.Model;
using System.CodeDom.Compiler;
using System.Security.Cryptography;

namespace CarStockAPI.Data
{
    public class DealerService : IDealers
    {

        public List<Dealer> DealerList;
        public Dictionary<string, string> Dict = new Dictionary<string, string>() { { "adminKey", "admin" } };

        public DealerService() { 
            DealerList = new List<Dealer>();
            LoadDealerData();
        }

        public Dealer RegisterDealer(string Id)
        {
            if (CheckExists(Id))
            {
                return null;
            }
            Dealer dealer = new Dealer(Id);
            DealerList.Add(dealer);
            Dict.Add(dealer.ApiKey,dealer.Id);
            return dealer;
        }


        public bool CheckExists(string Id)
        {
            foreach (Dealer d in DealerList)
            {
                if (d.Id == Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckKey(string Key)
        {
            if (Dict.ContainsKey(Key))
            {
                return true;
            }

            return false;
        }

        public List<KeyValuePair<string, string>> GetAllAPIKeys()
        {
            return Dict.ToList();
        }

        public string GetDealerId(string apiKey)
        {
            return Dict[apiKey];
        }
        private void LoadDealerData()
        {
            DealerList.Add(new Dealer("GenuineDealerA", "fy0+IixmcdniPyat8TeqKVIIvWw="));
            Dict.Add("fy0+IixmcdniPyat8TeqKVIIvWw=", "GenuineDealerA");

            DealerList.Add(new Dealer("GenuineDealerB", "ao4+Ti56fgthjKuip9AwdwXCsRv="));
            Dict.Add("ao4+Ti56fgthjKuip9AwdwXCsRv=","GenuineDealerB");

            DealerList.Add(new Dealer("GenuineDealerC", "hc9+Lk84nmzxyTyk3VeuBXWJsPo="));
            Dict.Add("hc9+Lk84nmzxyTyk3VeuBXWJsPo=", "GenuineDealerC");

            DealerList.Add(new Dealer("GenuineDealerD", "dv2+Ok59pqczYyu6FeuFTRVJpRs="));
            Dict.Add("dv2+Ok59pqczYyu6FeuFTRVJpRs=", "GenuineDealerD");

        }

    }
}
