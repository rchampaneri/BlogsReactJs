using System.Collections.Generic;

namespace Blogs.Data
{
    public interface IBlogService
    {
        List<Blogs> GetAllBlogs();
        Blogs GetBlogById(int id);
    }
}