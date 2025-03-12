using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Application.BlogImages.DTO
{
    public class BlogImageDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; } = default!;
        public string FileExtension { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Url { get; set; } = default!;
        public DateTime DateCreated { get; set; }
    }
}
