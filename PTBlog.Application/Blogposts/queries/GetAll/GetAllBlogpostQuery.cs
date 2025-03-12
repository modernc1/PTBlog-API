using MediatR;
using PTBlog.Application.Blogposts.DTO;


namespace PTBlog.Application.Blogposts.queries.GetAll
{
    public class GetAllBlogpostQuery : IRequest<List<BlogpostResponse>?>
    {
        public string? filter { get; set; } = null;
        public string sortBy { get; set; } = "DateCreated";
        public string sortDirection { get; set; } = "dec";
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
}
