using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PTBlog.Domain.Entities;
using PTBlog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.Categories.Commands.EditCategory
{
    internal class EditCategoryCommandHandler(ILogger<EditCategoryCommandHandler> logger,
        ICategoryRepository categoryRepository,
        IMapper mapper) : IRequestHandler<EditCategoryCommand>
    {
        public async Task Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("edit Category with Id: {id}", request.Id);

            var category = await categoryRepository.GetAsync(request.Id);

            if (category == null) throw new Exception($"category with Id:{request.Id} not found");

            category = mapper.Map<Category>(request);

            await categoryRepository.UpdateAsync(category);


        }
    }
}
