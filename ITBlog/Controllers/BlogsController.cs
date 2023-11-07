using ITBlog.Data;
using Microsoft.AspNetCore.Mvc;
using ITBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace ITBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogsController : ControllerBase
{

    private readonly ApiDbContext _context;

    public BlogsController(ApiDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Blogs.ToListAsync());
    }
        
    [HttpGet]
    [Route(template:"GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
        if (blog == null) return NotFound();
        
        return Ok(blog);
    }
        
    [HttpPost]
    [Route(template:"AddBlog")]
    public async Task<IActionResult> AddBlog(Blog blog)
    {
        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete]
    [Route(template:"DeleteBlog")]
    public async Task<IActionResult>DeleteBlog(int id)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

        if (blog == null) return NotFound();

        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpPatch]
    [Route(template:"UpdateBlog")]
    public async Task<IActionResult> UpdateBlog(Blog blog)
    {
        var existBlog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == blog.Id);
        if (existBlog == null) return NotFound();

        existBlog.Title = blog.Title;
        existBlog.Body = blog.Body;

        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    
}