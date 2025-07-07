using Api_Project.WebApi.Context;
using Api_Project.WebApi.Dtos.MessageDtos;
using Api_Project.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public MessageController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		[HttpGet]
		public IActionResult MessageList()
		{
			var values=_context.Messages.ToList();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));

		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			var value=_mapper.Map<Message>(createMessageDto);
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("Mesaj ekleme işlemi başarılı");
		}

		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var values = _context.Messages.Find(id);
			_context.Messages.Remove(values);
			_context.SaveChanges();
			return Ok("mesaj silme işlemi başarılı");
		}

		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id) 
		{ 
			var value=_context.Messages.Find(id);
			return Ok(_mapper.Map<GetByIdMessageDto>(value));
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var value=_mapper.Map<Message>(updateMessageDto);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Mesaj güncelleme başarılı");
		}
	}
}
