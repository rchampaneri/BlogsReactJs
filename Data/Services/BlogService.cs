using System.Collections.Generic;
using System.Linq;

namespace Blogs.Data
{
    public class BlogService : IBlogService
    {
        private readonly IDataRepository _db;
        public BlogService(IDataRepository db)
        {
            _db = db;
        }
        public List<Blogs> GetAllBlogs()
        {
            var blogs = _db.GetBlogs().Result;
            return blogs.ToList();
        }

        public Blogs GetBlogById(int id)
        {
            var objBlog = _db.GetBlogContentById(id).Result;
            return objBlog;
        }
    }
}