using Final.Data.Entities;
using Final.Service.Services;
using Final.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final.WebApi.Controllers 
{
    [Route("api/[controller]")] 
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            var cars = _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> PostCar([FromBody] Car car)
        {
            _carService.CreateCar(car);
            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult PutCar(int id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _carService.UpdateCar(id, car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            _carService.DeleteCar(id);
            return NoContent();
        }
    }
}