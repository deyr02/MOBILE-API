using API.DTO;
using AutoMapper;
using mobile_api.Model;

namespace mobile_api.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile(){

            CreateMap<Product, Product>();
            CreateMap<ProductCategoryDTO, ProductCategory>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            
        }

    }
}