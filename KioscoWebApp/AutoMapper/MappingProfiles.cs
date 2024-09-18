using AutoMapper;
using KioscoWebApp.Dto;
using KioscoWebApp.Models;

namespace KioscoWebApp.AutoMapper
{
    public class MappingProfiles : Profile

    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}
