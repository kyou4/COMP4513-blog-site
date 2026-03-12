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
    public class DeleteModel : PageModel
    {
        private readonly BLOGSITE.Data.BlogContext _context;

        public DeleteModel(BLOGSITE.Data.BlogContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                Post = post;
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
