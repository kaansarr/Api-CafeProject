using Api_Project.WebApi.Dtos.ContactDtos;
using Api_Project.WebApi.Dtos.FeatureDtos;
using Api_Project.WebApi.Dtos.MessageDtos;
using Api_Project.WebApi.Dtos.ProductDtos;
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


			CreateMap<Contact,ResultContactDto>().ReverseMap();
			CreateMap<Contact,CreateContactDto>().ReverseMap();
			CreateMap<Contact,GetByIdContactDto>().ReverseMap();
			CreateMap<Contact,UpdateContactDto>().ReverseMap();





			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap(); 
		}
	}
}
