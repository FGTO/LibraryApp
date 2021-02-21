using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public IndexModel(LibraryDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; } //IEnumerable list of book

        public async Task OnGet()   //Need to be async Task because we using await and ToListAsync.
                                    //Async will let you run multiple tasks at a time un till it si awaiting.

        {
            //Assign "Books" all of the books from the databse.
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
