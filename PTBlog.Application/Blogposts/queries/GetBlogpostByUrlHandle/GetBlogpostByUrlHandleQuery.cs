using MediatR;
using PTBlog.Application.Blogposts.DTO;


namespace PTBlog.Application.Blogposts.queries.GetBlogpostByUrlHandle
{
    public class GetBlogpostByUrlHandleQuery : IRequest<BlogpostResponse?>
    {
        public string UrlHandle { get; set; } = default!;
    }
}
