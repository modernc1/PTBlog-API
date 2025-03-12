using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Application.Categories.DTO;
using PTBlog.Domain.Repositories;


namespace PTBlog.Application.Categories.Queries.GetCategoryById;

internal class GetCategoryByIdQueryHandler(ILogger<GetCategoryByIdQueryHandler> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get Category with Id: {cate}", request.Id);

        var category = await categoryRepository.GetAsync(request.Id);
        if (category == null) throw new Exception("Not Found");
        
        var categoryResponse = mapper.Map<CategoryResponse>(category);
        
        return categoryResponse;
    }
}
