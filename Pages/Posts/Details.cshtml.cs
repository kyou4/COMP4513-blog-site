using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLOGSITE.Data;
using BLOGSITE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BLOGSITE.Pages_Posts
{
    public class DetailsModel : PageModel
    {
        private readonly BLOGSITE.Data.BlogContext _context;

        public DetailsModel(BLOGSITE.Data.BlogContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);

            if (post is not null)
            {
                Post = post;

                return Page();
            }

            return NotFound();
        }
    }
}
