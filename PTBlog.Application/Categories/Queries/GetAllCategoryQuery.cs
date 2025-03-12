using MediatR;
using PTBlog.Application.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<List<CategoryResponse>>
    {
        public string? filter { get; set; } = null;
        public string? sortBy { get; set; } = "name";
        public string? sortDirection { get; set; } = "asc";
    }
}
