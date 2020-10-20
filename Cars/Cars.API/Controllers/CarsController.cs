using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Core.Entities;
using Cars.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] PostCarDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _carRepository.AddCar(dto);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public IActionResult GetCars()
        {
            var carsResult = _carRepository.GetCars();

            return Ok(carsResult);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public IActionResult GetCar([FromRoute] int carId)
        {
            var car = _carRepository.GetCar(carId);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult PutCar([FromRoute] int id, [FromBody] Car putCar)
        {
            var editCar = _carRepository.UpdateCar(id, putCar);

            if (editCar == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        public IActionResult DeleteCar([FromRoute] int id)
        {
            var result = _carRepository.DeleteCar(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchCar(int id, [FromBody] JsonPatchDocument<Car> patchEntity)
        {
            var car = _carRepository.PatchCar(id);

            if (car == null)
            {
                return NotFound();
            }

            patchEntity.ApplyTo(car);

            return Ok(car);
        }
    }
}
