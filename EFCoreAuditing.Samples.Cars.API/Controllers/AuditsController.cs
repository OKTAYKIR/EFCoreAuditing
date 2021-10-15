using EFCoreAuditing.Models;
using Microsoft.AspNetCore.Mvc;
using Pagination.EntityFrameworkCore.Extensions;
using System.Threading.Tasks;

namespace EFCoreAuditing.Samples.Cars.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuditsController : ControllerBase
	{
		private readonly CarsrDbContext _context;
		public AuditsController(CarsrDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<Pagination<Audit>>> GetAudits(int page = 1, int limit = 20)
		{
			var audits = await _context.Audits.AsPaginationAsync(page, limit);
			return Ok(audits);
		}

	}
}
