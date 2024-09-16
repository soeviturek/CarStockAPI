namespace CarStockAPI.Model
{
    public class Car
    {
        public string Id { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }

        public string dealerId { get; set; }

        public int StockLevel { get; set; }
        private int ID_LENGTH = 20;


        public Car(string Make,string Model,int Year,string dealerId,int stockLevel)
        {
            GenerateId();
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.dealerId = dealerId;
            this.StockLevel = stockLevel;
        }
        public Car(string id, string Make, string Model, int Year,string dealerId, int stockLevel)
        {
            this.Id = id;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.dealerId = dealerId;
            StockLevel = stockLevel;
        }

        private void GenerateId()
        {
            Id =  Guid.NewGuid().ToString("N");
        }

        public override string ToString()
        {
            return String.Format("Make:{0},\nModel:{1},\nYear:{2},\n,Stock Level:{3}",Make,Model,Year,StockLevel);
        }
    }
}
