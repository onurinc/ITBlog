using ITBlog.Models;
using ITBlog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ITBlog.Core.Repositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(ApiDbContext context, ILogger logger) : base(context, logger)
    {
        
    }

    public override async Task<Blog?> GetById(int id)
    {
        try
        {
            return await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


}