using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public CreateModel(LibraryDbContext db)
        {
            _db = db;
        }

        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(Book bookObj)
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
