using Final.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Data.Interfaces;
using Final.Data.Entities;

namespace Final.Service.Services 
{
    public interface ICarService 
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void CreateCar(Car car); 
        void UpdateCar(int id, Car car);
        void DeleteCar(int id);
    }
}
