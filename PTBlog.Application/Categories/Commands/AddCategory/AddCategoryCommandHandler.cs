

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Categories.Commands.AddCategory;

internal class AddCategoryCommandHandler(ILogger<AddCategoryCommandHandler> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper)
    : IRequestHandler<AddCategoryCommand>
{

    async Task IRequestHandler<AddCategoryCommand>.Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new Category : {@Request}", request);

        var category = mapper.Map<Category>(request);
        
        await categoryRepository.CreateAsync(category);

    }
}
