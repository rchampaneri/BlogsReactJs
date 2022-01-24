using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Blogs.Data
{
    public interface IDataRepository : IDisposable
    {
        Task<List<Blogs>> GetBlogs();
        Task<Blogs> GetBlogContentById(int id);
    }

    public class DataRepository : IDataRepository
    {
        internal IDbConnection _db => new SqlConnection(Globals.DBConnectionString);
        public async Task<List<Blogs>> GetBlogs()
        {
            List<Blogs> blogList = new List<Blogs>();

            string query = @"select b.BlogPostId as [Id],
	   b.Title as [Title], 
	   b.PublishedOn as [PublishedDate],
       b.Body As [BodyContents],
	   count(c.commentId) as [NumberOfComments]
from BlogPosts b inner join BlogComment c
on b.BlogPostID = c.BlogPostID
group by b.BlogPostId, b.title, b.publishedOn,b.Body";

            try
            {
                blogList = (await _db.QueryAsync<Blogs>(query).ConfigureAwait(false)).ToList();
            }
            catch (Exception ex)
            {
              
            }

            return blogList;
        }

        public async Task<Blogs> GetBlogContentById(int id)
        {
            Blogs objBlog = new Blogs();

            string query = @"SELECT BlogPostID as [Id],
	   Title as [Title], 
	   PublishedOn as [PublishedDate], 
       Body As [BodyContents] from BlogPosts where BlogPostId = @b_Id";

            try
            {
                objBlog = (await _db.QueryAsync<Blogs>(query, new { b_Id = id }).ConfigureAwait(false)).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            return objBlog;
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                disposed = true;
            }
        }

        ~DataRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}

