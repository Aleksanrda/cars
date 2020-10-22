using System;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Core.Entities;
using Cars.Core.Repositories;
using Cars.Core.Services;
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
        private readonly ICarsService _carsService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public CarsController(ICarsService carsService,
            ILogger<CarsController> logger, IMapper mapper)
        {
            _carsService = carsService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostCar([FromBody] CarViewModel viewModel)
        {
            _logger.LogInformation("POST method called");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation("ModelState.IsValid");

            var car = _mapper.Map<Car>(viewModel);

            var newCar = await _carsService.AddCarAsync(car);

            return Ok(newCar);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCars()
        {
            _logger.LogInformation("GetCars method called");

            var cars = await _carsService.GetCarsAsync();

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

            var car = await _carsService.GetCarAsync(carId);

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
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Model state is valid");

            var editCar = await _carsService.UpdateCarAsync(id, putCar);

            return Ok(editCar);
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

            await _carsService.DeleteCarAsync(id);

            return Ok();
        }
    }
}
