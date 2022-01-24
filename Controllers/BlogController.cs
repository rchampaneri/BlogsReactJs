using System;
using Microsoft.AspNetCore.Mvc;
using Blogs.Data;

namespace Blogs.Controllers
{
    [Route("api/[controller]")]
    public class BlogController: Controller
    {
        private IBlogService _service;
       
        public BlogController(IBlogService service)
        {
            this._service = service;
        }

        [HttpGet("[action]")]
        public IActionResult GetBlogs()
        {
            try 
            {
                var allBlogs = _service.GetAllBlogs();
                return Ok(allBlogs);

            } catch(Exception ex){
                
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("Blog/{id}")]
        public IActionResult GetBlogById(int id)
        {
            var blog = _service.GetBlogById(id);
            return Ok(blog);
        }
    }
}