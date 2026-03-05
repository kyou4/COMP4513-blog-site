using Microsoft.EntityFrameworkCore;

namespace BLOGSITE.Models;

public class Post
{
    public string Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Concent { get; set; } = string.Empty;
}
