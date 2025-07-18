﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api_Project.WebApi.Entities
{
	public class Service
	{
		public int ServiceID  { get; set; }

		public string Title {  get; set; } 
		public string Description {  get; set; } 
		public string IconUrl {  get; set; } 
	}
}
