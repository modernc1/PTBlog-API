using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.BlogImages.commands.DeleteBlogImage
{
    public class DeleteBlogImageCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
