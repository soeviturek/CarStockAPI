namespace CarStockAPI.Model
{
    public class Car
    {
        public string Id { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }

        public string dealerId { get; set; }

        private int ID_LENGTH = 20;


        public Car(string Make,string Model,int Year,string dealerId)
        {
            GenerateId();
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.dealerId = dealerId;
        }
        public Car(string id, string Make, string Model, int Year,string dealerId)
        {
            this.Id = id;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.dealerId = dealerId;
        }

        private void GenerateId()
        {
            Id =  Guid.NewGuid().ToString("N");
        }

        public override string ToString()
        {
            return String.Format("Make:{0},\nModel:{1},\nYear:{2}",Make,Model,Year);
        }
    }
}
