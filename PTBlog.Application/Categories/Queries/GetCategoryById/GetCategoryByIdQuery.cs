using MediatR;
using PTBlog.Application.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string UrlHandle { get; set; } = default!;

    }
}
