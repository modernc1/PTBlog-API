using MediatR;


namespace PTBlog.Application.Categories.Commands.EditCategory;

public class EditCategoryCommand : IRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string UrlHandle { get; set; } = default!;
}
