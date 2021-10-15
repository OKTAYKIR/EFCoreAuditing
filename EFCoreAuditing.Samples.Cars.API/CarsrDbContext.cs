using EFCoreAuditing.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreAuditing.Samples.Cars.API
{
	public class CarsrDbContext : AuditLogDbContext<Guid>
	{
		public CarsrDbContext(DbContextOptions<CarsrDbContext> dbOptions)
			: base(dbOptions)
		{
		}

		public DbSet<Car> Cars { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder
				.SnakeCaseifyNames() //Change all the table names and column names to snake_case.
				.EnableSoftDelete(); //Enable soft-delete functionality.
		}
	}
}
