using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLOGSITE.Data;
using BLOGSITE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BLOGSITE.Pages_Categories
{
    public class DetailsModel : PageModel
    {
        private readonly BLOGSITE.Data.BlogContext _context;

        public DetailsModel(BLOGSITE.Data.BlogContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context
                .Categories.Include(c => c.Posts)
                    .ThenInclude(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category is not null)
            {
                Category = category;

                return Page();
            }

            return NotFound();
        }
    }
}
