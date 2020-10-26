using System;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Core.Entities;
using Cars.Core.Repositories;
using Cars.Core.Services;
using Cars.ViewModel;
using Cars.ViewModel.ViewModels;
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
        public async Task<IActionResult> PostCar([FromBody] CreatedCarViewModel viewModel)
        {
            _logger.LogInformation("POST method is called");

            _logger.LogInformation("ModelState.IsValid");

            var car = _mapper.Map<Car>(viewModel);

            var newCar = await _carsService.AddCarAsync(car);

            return Ok(newCar);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCars()
        {
            _logger.LogInformation("GetCars method is called");

            var cars = await _carsService.GetCarsAsync();

            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(typeof(Car[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCar([FromRoute] string carId)
        {
            _logger.LogInformation("GetCar method is called");

            var car = await _carsService.GetCarAsync(carId);

            if (car == null)
            {
                _logger.LogWarning("Get {Id} NOT FOUND", carId);

                return NotFound();
            }

            return Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar([FromRoute] string id, 
            [FromBody] UpdatedCarViewModel updatedCarViewModel)
        {
            _logger.LogInformation("PutCar method is called");

            _logger.LogInformation("Model state is valid");

            var car = _mapper.Map<Car>(updatedCarViewModel);
            var updatedCar = await _carsService.UpdateCarAsync(id, car);

            if (updatedCar == null)
            {
                return BadRequest();
            }

            return Ok(updatedCar);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCar([FromRoute] string id)
        {
            _logger.LogInformation("DeleteCar method is called");

            var car = await _carsService.DeleteCarAsync(id);

            if (car == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
