using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.EntityFrameworkCore.Extensions;
using System;
using System.Threading.Tasks;

namespace EFCoreAuditing.Samples.Cars.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CarsController : ControllerBase
	{
		private readonly CarsrDbContext _context;
		public CarsController(CarsrDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<CarViewModel>> AddCar(AddOrUpdateCarEntity entity)
		{
			if (string.IsNullOrEmpty(entity?.Brand))
			{
				return BadRequest("Brand is required.");
			}
			if (string.IsNullOrEmpty(entity?.RegistrationNumber))
			{
				return BadRequest("RegistrationNumber is required.");
			}
			if (string.IsNullOrEmpty(entity?.MarketValue))
			{
				return BadRequest("MarketValue is required.");
			}
			if (string.IsNullOrEmpty(entity?.Owner))
			{
				return BadRequest("Owner is required.");
			}
			var car = new Car
			{
				Brand = entity.Brand,
				CreatedDate = DateTimeOffset.UtcNow,
				Id = Guid.NewGuid(),
				MarketValue = entity.MarketValue,
				Owner = entity.Owner,
				RegistrationNumber = entity.RegistrationNumber,
			};
			var addedCar = _context.Cars.Add(car);
			await _context.SaveChangesAsync();
			return Ok(ConvertToCarViewModel(addedCar.Entity));
		}

		[HttpPut("id")]
		public async Task<ActionResult<CarViewModel>> UpdateCar(Guid id, AddOrUpdateCarEntity entity)
		{
			if (string.IsNullOrEmpty(entity?.Brand))
			{
				return BadRequest("Brand is required.");
			}
			if (string.IsNullOrEmpty(entity?.RegistrationNumber))
			{
				return BadRequest("RegistrationNumber is required.");
			}
			if (string.IsNullOrEmpty(entity?.MarketValue))
			{
				return BadRequest("MarketValue is required.");
			}
			if (string.IsNullOrEmpty(entity?.Owner))
			{
				return BadRequest("Owner is required.");
			}
			var car = await _context.Cars.FirstOrDefaultAsync(a => a.Id == id);
			if (car == null)
			{
				return NotFound();
			}
			car.Brand = entity.Brand;
			car.RegistrationNumber = entity.RegistrationNumber;
			car.MarketValue = entity.MarketValue;
			car.Owner = entity.Owner;

			var addedCar = _context.Cars.Update(car);
			await _context.SaveChangesAsync();
			return Ok(ConvertToCarViewModel(addedCar.Entity));
		}

		[HttpGet("id")]
		public async Task<ActionResult<CarViewModel>> GetCar(Guid id)
		{

			var car = await _context.Cars.FirstOrDefaultAsync(a => a.Id == id);
			if (car == null)
			{
				return NotFound();
			}
			var addedCar = _context.Cars.Update(car);
			await _context.SaveChangesAsync();
			return Ok(ConvertToCarViewModel(addedCar.Entity));
		}

		[HttpGet]
		public async Task<ActionResult<Pagination<CarViewModel>>> GetCars(int page = 1, int limit = 20)
		{
			var cars = await _context.Cars.AsPaginationAsync(page, limit, ConvertToCarViewModel);
			return Ok(cars);
		}

		private CarViewModel ConvertToCarViewModel(Car car)
		{
			return new CarViewModel
			{
				Brand = car.Brand,
				Id = car.Id,
				CreatedDate = car.CreatedDate,
				MarketValue = car.MarketValue,
				Owner = car.Owner,
				RegistrationNumber = car.RegistrationNumber
			};
		}
	}
}
