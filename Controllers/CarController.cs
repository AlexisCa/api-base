using ApiProyectBase.Data.Repositories;
using ApiProyectBase.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyectBase.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarAll()
        {
            return Ok(await _carRepository.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDeail(int id)
        {
            return Ok(await _carRepository.GetCarDetail(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody]Car car)
        {
            if(car == null)
                return BadRequest();
            
            if(!ModelState.IsValid)
                return BadRequest();

            var create = await _carRepository.InsertCar(car);

            return Created("create", create);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            if (car == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            await _carRepository.UpdateCar(car);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCar(new Car { Id = id });
            return NoContent();
        }
    }
}
