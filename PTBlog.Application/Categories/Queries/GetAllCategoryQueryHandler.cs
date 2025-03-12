using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Categories.DTO;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;

namespace PTBlog.Application.Categories.Queries;

internal class GetAllCategoryQueryHandler(ILogger<GetAllCategoryQueryHandler> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<GetAllCategoryQuery, List<CategoryResponse>>
{
    public async Task<List<CategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get All Categories");

        var Categories = await categoryRepository.GetAllAsync(request.filter != null? request.filter : null,
                                                              request.sortBy != "name"? request.sortBy : "name",
                                                              request.sortDirection != "asc"? request.sortDirection : "asc");

        var CategoriesDto = mapper.Map<List<CategoryResponse>>(Categories);

        return CategoriesDto;
    }
}
