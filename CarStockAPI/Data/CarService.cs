using System.Collections;
using CarStockAPI.Model;

namespace CarStockAPI.Data
{
    public class CarService : ICar
    {

        public List<Car> Cars;

        public CarService() { 
            Cars = new List<Car>();
            LoadCarData();
        }
        public List<Car> GetAllCar(string dealerId)
        {
            List<Car> cars = new List<Car>();
            foreach(var car in Cars)
            {
                if (car.dealerId.Equals(dealerId))
                {
                    cars.Add(car);
                }
            }
            return cars;
        }
        public Car GetCar(string carId, string dealerId)
        {
            foreach (var car in Cars)
            {
                if (car.Id.Equals(carId) && car.dealerId.Equals(dealerId))
                {
                    return car;
                }
            }
            return null;
        }
        public bool AddCar(Car car)
        {
            Cars.Add(car);
            return true;
        }
        public bool EditCar(Car car)
        {
            foreach (Car c in Cars)
            {
                if (c.Id.Equals(car.Id) && c.dealerId.Equals(car.dealerId))
                {
                    c.Model = car.Model;
                    c.Make  = car.Make;
                    c.Year = car.Year;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveCar(string id, string dealerId)
        {
            foreach(var car in Cars)
            {
                if(car.Id.Equals(id) && car.dealerId.Equals(dealerId))
                {
                    Cars.Remove(car);
                    return true;
                }
            }
            return false; 
            
        }

        private void LoadCarData()
        {
            Cars.Add(new Car("Audi", "A4", 2018, "admin"));
            Cars.Add(new Car("BMW", "X5", 2020, "admin"));
            Cars.Add(new Car("Toyota", "Corolla", 2017, "GenuineDealerA"));
            Cars.Add(new Car("Honda", "Civic", 2019, "GenuineDealerA"));
            Cars.Add(new Car("Mercedes-Benz", "C-Class", 2021, "GenuineDealerA"));
            Cars.Add(new Car("Ford", "Mustang", 2018, "GenuineDealerA"));
            Cars.Add(new Car("Chevrolet", "Malibu", 2016, "GenuineDealerA"));
            Cars.Add(new Car("Hyundai", "Elantra", 2019, "GenuineDealerA"));
            Cars.Add(new Car("Nissan", "Altima", 2020, "GenuineDealerB"));
            Cars.Add(new Car("Volkswagen", "Jetta", 2017, "GenuineDealerB"));
            Cars.Add(new Car("Tesla", "Model 3", 2021, "GenuineDealerB"));
            Cars.Add(new Car("Mazda", "CX-5", 2019, "GenuineDealerB"));
            Cars.Add(new Car("Kia", "Optima", 2018, "GenuineDealerC"));
            Cars.Add(new Car("Subaru", "Impreza", 2020, "GenuineDealerC"));
            Cars.Add(new Car("Volvo", "XC90", 2017, "GenuineDealerC"));
            Cars.Add(new Car("Lexus", "RX 350", 2019, "GenuineDealerCA"));
            Cars.Add(new Car("Dodge", "Charger", 2021, "GenuineDealerC"));
            Cars.Add(new Car("Jeep", "Grand Cherokee", 2020, "GenuineDealerC"));
            Cars.Add(new Car("Infiniti", "Q50", 2018, "GenuineDealerC"));
            Cars.Add(new Car("Porsche", "Cayenne", 2017, "GenuineDealerD"));

        }
    }
}
