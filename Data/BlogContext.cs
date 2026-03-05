using BLOGSITE.Models;
using Microsoft.EntityFrameworkCore;

namespace BLOGSITE.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options) { }

    public DbSet<Post> Post { get; set; } = default!; // database table
}
