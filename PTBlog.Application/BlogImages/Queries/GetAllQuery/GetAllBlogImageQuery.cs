using MediatR;
using PTBlog.Domain.Entities;


namespace PTBlog.Application.BlogImages.Queries.GetAllQuery;

public class GetAllBlogImageQuery : IRequest<List<BlogImage>?>
{
}
