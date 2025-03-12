using AutoMapper;
using PTBlog.Application.Categories.Commands.AddCategory;
using PTBlog.Application.Categories.Commands.EditCategory;
using PTBlog.Domain.Entities;


namespace PTBlog.Application.Categories.DTO
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryCommand, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryResponse, Category>();
            CreateMap<EditCategoryCommand, Category>();
        }
    }
}
