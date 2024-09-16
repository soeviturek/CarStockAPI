using CarStockAPI.Model;

namespace CarStockAPI.Data
{
    public interface ICar
    {
        public List<Car> GetAllCar(string dealerId);

        public Car GetCar(string carId, string dealerId);

        public List<Car> GetByMakeModel(string make, string models, string dealerId);

        public bool AddCar(Car car);
        public bool EditCar(Car car);
        public bool RemoveCar(string id, string dealerId);
    }
}
