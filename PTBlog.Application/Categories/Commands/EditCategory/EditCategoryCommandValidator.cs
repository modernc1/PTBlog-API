using FluentValidation;

namespace PTBlog.Application.Categories.Commands.EditCategory;

public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(category => category.Name).Length(3, 20);
        RuleFor(category => category.Name).NotEmpty();

    }
}
