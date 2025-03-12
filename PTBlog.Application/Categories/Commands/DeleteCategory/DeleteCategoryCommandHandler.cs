using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Domain.Repositories;


namespace PTBlog.Application.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandHandler(ILogger<DeleteCategoryCommandHandler> logger,
        ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
    {
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting Category with Id: {id}", request.Id);

            var category = await categoryRepository.GetAsync(request.Id);

            if (category == null) throw new Exception("category not Found");

            await categoryRepository.DeleteAsync(request.Id);
        }
    }
}
