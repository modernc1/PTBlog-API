using AutoMapper;
using PTBlog.Application.Blogposts.commands.AddBlogpost;
using PTBlog.Application.Blogposts.commands.UpdateBlogpost;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;


namespace PTBlog.Application.Blogposts.DTO
{
    public class BlogpostProfile : Profile
    {
        public BlogpostProfile()
        {
            CreateMap<AddBlogpostCommand, BlogPost>()
                .ForMember(c => c.Categories, opt=> opt.Ignore());

            CreateMap<BlogPost, AddBlogpostCommand>();

            CreateMap<BlogPost, BlogpostResponse>()
                .ForMember(c => c.Categories, opt => opt.MapFrom(c => c.Categories.Select(c => c.Category)));


            //CreateMap<UpdateBlogpostCommand, BlogPost>()
            //    .ForMember(blogpost => blogpost.Categories, opt=> opt.UseDestinationValue()).ForAllMembers(opt => opt.MapFrom(src => src));
            //    // ignored properties in automapper set to its default which is null
            //                                                                                  // UseDestinationValue Keep The value as it is without changing it
        }
    }

}
