using ITBlog.Models;

namespace ITBlog.Core;

public interface IBlogRepository : IGenericRepository<Blog>
{
    Task<Blog> GetBlogById(int blogId);
}