using ITBlog.Core;
using Microsoft.AspNetCore.Mvc;
using ITBlog.Models;

namespace ITBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogsController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;

    public BlogsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Blogs.All());
    }
        
    [HttpGet]
    [Route(template:"GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var blog = await _unitOfWork.Blogs.GetById(id);
        if (blog == null) return NotFound();
        
        return Ok(blog);
    }
        
    [HttpPost]
    [Route(template:"AddBlog")]
    public async Task<IActionResult> AddBlog(Blog blog)
    {
        _unitOfWork.Blogs.Add(blog);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
    
    [HttpDelete]
    [Route(template:"DeleteBlog")]
    public async Task<IActionResult>DeleteBlog(int id)
    {
        var blog = await _unitOfWork.Blogs.GetById(id);

        if (blog == null) return NotFound();
 
        await _unitOfWork.Blogs.Delete(blog);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
    
    [HttpPatch]
    [Route(template:"UpdateBlog")]
    public async Task<IActionResult> UpdateBlog(Blog blog)
    {
        var existBlog = await _unitOfWork.Blogs.GetById(blog.Id);
        if (existBlog == null) return NotFound();

        await _unitOfWork.Blogs.Update(blog);
        await _unitOfWork.CompleteAsync();
        
        
        return NoContent();
    }
    
    
}