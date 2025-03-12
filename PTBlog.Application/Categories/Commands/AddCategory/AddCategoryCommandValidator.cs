using FluentValidation;

namespace PTBlog.Application.Categories.Commands.AddCategory;

public class EditCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(category => category.Name).Length(3, 20);
        RuleFor(category => category.Name).NotEmpty();

    }
}
