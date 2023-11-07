using Microsoft.AspNetCore.Mvc;
using ITBlog.Models;

namespace ITBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogsController : ControllerBase
{
    private readonly List<Blog> _blogs = new List<Blog>()
    {
        new Blog()
        {
            Id = 1,
            Title = "Title",
            Body = "Body"
        },
        new Blog()
        {
            Id = 2,
            Title = "TitleTwo",
            Body = "BodyTwo"
        },
    };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blogs);
        }
        
}