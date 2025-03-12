using FluentValidation;
using PTBlog.Domain.Static;


namespace PTBlog.Application.BlogImages.commands.UploadBlogImage
{
    public class UploadImageCommandValidator : AbstractValidator<UploadBlogImageCommand>
    {
        public UploadImageCommandValidator()
        {
            RuleFor(c => c.File).Must(c => c.Length < StaticData.AllowedImageSize)
                .WithMessage("File Size Cann't be more than 10MB");

            RuleFor(c=> c.File.FileName).Must(c => StaticData.AllowedImageExtension.Contains(Path.GetExtension(c).ToLower()))
                .WithMessage($"Unsupported File Format, Make Sure File Extension is one of the following: {String.Join(", " ,StaticData.AllowedImageExtension)}");

        }
    }
}
