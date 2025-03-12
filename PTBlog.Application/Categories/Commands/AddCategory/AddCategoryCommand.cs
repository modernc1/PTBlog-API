using MediatR;
using System.ComponentModel.DataAnnotations;


namespace PTBlog.Application.Categories.Commands.AddCategory;

public class AddCategoryCommand : IRequest
{
    
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string UrlHandle { get; set; } = default!;

}
