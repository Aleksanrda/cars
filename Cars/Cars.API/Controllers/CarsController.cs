using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Core.Entities;
using Cars.Core.Repositories;
using Cars.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cars.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public CarsController(ICarRepository carRepository, 
            ILogger<CarsController> logger, IMapper mapper)
        {
            _carRepository = carRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] CarViewModel dto)
        {
            _logger.LogInformation("POST method called");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is not valid");

                return BadRequest(ModelState);
            }

            var car = _mapper.Map<Car>(dto);

            _carRepository.AddCar(car);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public IActionResult GetCars()
        {
            _logger.LogInformation("GetCars method called");

            var carsResult = _carRepository.GetCars();

            return Ok(carsResult);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public IActionResult GetCar([FromRoute] int carId)
        {
            _logger.LogInformation("GetCar method called");

            var car = _carRepository.GetCar(carId);

            if (car == null)
            {
                _logger.LogWarning("Get ({Id}) NOT FOUND", carId);

                return NotFound();
            }

            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult PutCar([FromRoute] int id, [FromBody] Car putCar)
        {
            _logger.LogInformation("PutCar method called");

            var editCar = _carRepository.UpdateCar(id, putCar);

            if (editCar == null)
            {
                _logger.LogWarning("Get ({Id}) NOT FOUND", id);

                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        public IActionResult DeleteCar([FromRoute] int id)
        {
            _logger.LogInformation("DeleteCar method called");

            var result = _carRepository.DeleteCar(id);

            if (!result)
            {
                _logger.LogWarning("Get ({Id}) NOT FOUND", id);

                return NotFound();
            }

            return Ok();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchCar(int id, [FromBody] JsonPatchDocument<Car> patchEntity)
        {
            _logger.LogInformation("PatchCar method called");

            var car = _carRepository.PatchCar(id);

            if (car == null)
            {
                _logger.LogWarning("Get ({Id}) NOT FOUND", id);

                return NotFound();
            }

            patchEntity.ApplyTo(car);

            return NoContent();
        }
    }
}
