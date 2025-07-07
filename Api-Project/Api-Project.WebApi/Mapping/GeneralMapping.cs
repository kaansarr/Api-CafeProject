using Api_Project.WebApi.Dtos.FeatureDtos;
using Api_Project.WebApi.Dtos.MessageDtos;
using Api_Project.WebApi.Entities;
using AutoMapper;

namespace Api_Project.WebApi.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping()
		{
			CreateMap<Feature,ResultFeatureDto>().ReverseMap();
			CreateMap<Feature,CreateFeatureDto>().ReverseMap();
			CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
			CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();


			CreateMap<Message,ResultMessageDto>().ReverseMap();
			CreateMap<Message,CreateMessageDto>().ReverseMap();
			CreateMap<Message,GetByIdMessageDto>().ReverseMap();
			CreateMap<Message,UpdateMessageDto>().ReverseMap();
		}
	}
}
