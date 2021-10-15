﻿using System;

namespace EFCoreAuditing.Samples.Cars.API
{
	public class CarViewModel
	{
		public Guid Id { get; set; }
		public string Brand { get; set; }
		public string RegistrationNumber { get; set; }
		public string Owner { get; set; }
		public string MarketValue { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
	}
}