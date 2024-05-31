using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Data;
using Final.Services;
using Xunit.Abstractions;
using Final.Data.Interfaces;
using Final.Services.Services;
using Final.Data.Entities;

namespace Final.Tests.UnitTests 
{
    public class CarTests 
    {
        private readonly Mock<ICarRepository> _mockCarRepository;
        private readonly CarService _carService;

        public CarTests()
        {
            _mockCarRepository = new Mock<ICarRepository>();
        _carService = new CarService(_mockCarRepository.Object);
        }

        [Fact]
        public void GetAllCars_ShouldReturnAllCars()
        {
            var cars = new List<Car>
            {
                new Car { Id = 1,LicensePlate = "SK1111BI", Model = "Megane", Manufacturer="M Doo" }, 
                new Car { LicensePlate = "SK2222BI", Model = "Clio", Manufacturer="LL Doo" } 
            };
            _mockCarRepository.Setup(repo => repo.GetAllCars()).Returns(cars);

            var result = _carService.GetAllCars();

            Assert.Equal(cars, result);
        }

        [Fact]
        public void GetCarById_ShouldReturnCar_WhenCarExists() 
        {
            var car = new Car { Id = 1, LicensePlate = "SK1111BI", Model = "Megane", Manufacturer = "M Doo" };
            _mockCarRepository.Setup(repo => repo.GetCarById(1)).Returns(car);

            var result = _carService.GetCarById(1);

            Assert.Equal(car, result);
        }

        [Fact]
        public void CreateCar_ShouldCallRepositoryCreateCar()
        {
            var car = new Car { Id = 1, LicensePlate = "SK1111BI", Model = "Megane", Manufacturer = "M Doo" };

            _carService.CreateCar(car);

            _mockCarRepository.Verify(repo => repo.CreateCar(car), Times.Once);
        }
    }
}