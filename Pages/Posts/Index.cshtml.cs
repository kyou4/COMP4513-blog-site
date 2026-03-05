using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BLOGSITE.Data;
using BLOGSITE.Models;

namespace BLOGSITE.Pages_Posts
{
    public class IndexModel : PageModel
    {
        private readonly BLOGSITE.Data.BlogContext _context;

        public IndexModel(BLOGSITE.Data.BlogContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Post.ToListAsync();
        }
    }
}
