using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBlog.Domain.Static
{
    public static class StaticData
    {
        public static readonly string[]  AllowedImageExtension = [".jpg", ".jpeg", ".png"];

        public const int AllowedImageSize = 10485760; // = 10MB

        public const string ReaderRole = "Reader";
        public const string WriterRole = "Writer";
    }
}
