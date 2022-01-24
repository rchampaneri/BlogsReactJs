using System;

namespace Blogs.Data
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BodyContents { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int NumberOfComments { get; set; }
    }
}
