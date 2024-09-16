using System;
using System.Security.Cryptography;

namespace CarStockAPI.Model
{
    public class Dealer
    {
        public string Id { get; set; }

        public string ApiKey { get; set; }

        private const int TOKEN_LENGTH = 20;

        public Dealer(string id){
            Id = id;
            ApiKey = GenerateApiKey();
        }
        public Dealer(string id, string apiKey)
        {
            Id = id;
            ApiKey = apiKey;
        }

        private string GenerateApiKey()
        {
            var key = new byte[TOKEN_LENGTH];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            return Convert.ToBase64String(key);
        }

        public override string ToString()
        {
            return String.Format("Dealer Id:{0},\nApi Key:{1}",Id,ApiKey);
        }
    }
}
