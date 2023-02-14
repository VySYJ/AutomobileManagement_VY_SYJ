
using AutomobileLibrary.BussinessObject;
namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        //khoi tao danh sach car
        private static List<Car> CarList = new List<Car>() {
           new Car{ CarID=1, CarName="CRV", Manufacturer="Honda",
             Price=30000, ReleaseYear=2021},
           new Car{ CarID=1, CarName="CRV", Manufacturer="Honda",
              Price=30000, ReleaseYear=2021},
        };

        //Using Singleton Pattern
        private static CarDBContext instance = null;
        private static readonly object intanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            {
                lock (intanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        public List<Car> GetCarList => CarList;

        public Car GetCarByID(int carID)
        {
            //Using LINQ to Object
            Car car = CarList.SingleOrDefault(pro => pro.CarID == carID);
            return car;        
        }
        //Add new a car
        public void Addnew(Car car)
        {
            Car pro = GetCarByID(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exists.");
            }
        }
        //Uptade a car
        public void Update(Car car)
        {
            Car CarUpdate = GetCarByID(car.CarID);
            if(CarUpdate != null)
            {
                var index = CarList.IndexOf(CarUpdate);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }
        //Remove a Car
        public void Remove(int CarID)
        {
            Car CarRemove = GetCarByID(CarID);
            if(CarRemove != null)
            {
                CarList.Remove(CarRemove);
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }

    }
}