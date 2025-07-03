﻿using Api_Project.WebApi.Context;
using Api_Project.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChefsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ChefsController(ApiContext context)
		{
			_context = context;
		}


		[HttpGet]
		public IActionResult ChefList() 
		{ 
			var values=_context.Chefs.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateChef(Chef chef)
		{
			_context.Chefs.Add(chef);
			_context.SaveChanges();
			return Ok("Şef Sisteme eklendi");
		}


		[HttpDelete]
		public IActionResult DeleteChef(int id)
		{
			var values=_context.Chefs.Find(id);
			_context.Chefs.Remove(values);
			_context.SaveChanges();
			return Ok("Şef sistemden silindi");

		}

		[HttpGet("GetChef")]
		public IActionResult GetChef(int id) 
		{ 
			var values= _context.Chefs.Find(id);
			return Ok(values);
		}


		[HttpPut]
		public IActionResult UpdateChef(Chef chef)
		{
			_context.Chefs.Update(chef);
			_context.SaveChanges();
			return Ok("Şef Güncellendi");
		}
	}
}
