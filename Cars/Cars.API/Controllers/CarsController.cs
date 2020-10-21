using System;
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
        public async Task<IActionResult> PostCar([FromBody] CarViewModel dto)
        {
            _logger.LogInformation("POST method called");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is not valid");

                return BadRequest(ModelState);
            }

            var car = _mapper.Map<Car>(dto);

            car.Id = Guid.NewGuid().ToString();
            await _carRepository.AddCarAsync(car);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCars()
        {
            _logger.LogInformation("GetCars method called");

            var cars = await _carRepository.GetCarsAsync("SELECT * FROM c");

            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCar([FromRoute] string carId)
        {
            _logger.LogInformation("GetCar method called");

            if (carId == null)
            {
                _logger.LogWarning("BadRequest");

                return BadRequest();
            }

            var car = await _carRepository.GetCarAsync(carId);

            if (car == null)
            {
                _logger.LogWarning("Get ({Id}) NOT FOUND", carId);

                return NotFound();
            }

            return Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar([FromRoute] string id, [FromBody] Car putCar)
        {
            _logger.LogInformation("PutCar method called");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is not valid");

                return BadRequest(ModelState);
            }

            await _carRepository.UpdateCarAsync(id, putCar);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCar([FromRoute] string id)
        {
            _logger.LogInformation("DeleteCar method called");

            if (id == null)
            {
                _logger.LogWarning("BadRequest");

                return BadRequest();
            }

            await _carRepository.DeleteCarAsync(id);

            return Ok();
        }
    }
}
