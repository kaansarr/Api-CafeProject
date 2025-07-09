using Api_Project.WebApi.Context;
using Api_Project.WebApi.Dtos.ContactDtos;
using Api_Project.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public ContactsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values=_context.Contacts.ToList();
			return Ok(_mapper.Map<List<ResultContactDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{ 
			var value=_mapper.Map<Contact>(createContactDto);
			_context.Contacts.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme İşlemi Başarılı");
		}

		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return Ok("başarıyla silindi");
		}

		[HttpGet("GetContact")]
		public IActionResult GetContact(int id) 
		{
			var value= _context.Contacts.Find(id);
			return Ok(_mapper.Map<GetByIdContactDto>(value));
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto) 
		{
			var value=_mapper.Map<Contact>(updateContactDto);
			_context.Contacts.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme işlemi başarılı");
		}
	}
}