using Api_Project.WebApi.Context;
using Api_Project.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IValidator<Product> _validator;
		private readonly ApiContext _context;

		public ProductController(IValidator<Product> validator, ApiContext context)
		{
			_validator = validator;
			_context = context;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _context.Products.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateProduct(Product product)
		{
			var validationResult=_validator.Validate(product);
			if (!validationResult.IsValid) { 
				return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
			}
			else
			{
				_context.Products.Add(product);
				_context.SaveChanges();
				return Ok("Ürün ekleme işlemi başarılı");
			}

		}

		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var value = _context.Products.Find(id);
			_context.Products.Remove(value);
			_context.SaveChanges();
			return Ok("Silme başarılı");
		}

		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			var value=_context.Products.Find(id);
			return Ok(value);	
		}


		[HttpPut]
		public IActionResult UpdateProduct(Product product)
		{
			var validationResult=_validator.Validate(product);
			if ((!validationResult.IsValid))
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{ 
				_context.Products.Update(product);
				_context.SaveChanges();
				return Ok("Ürün güncelleme başarılı");
			}
		}
	}
}
