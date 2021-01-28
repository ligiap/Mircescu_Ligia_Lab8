
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mircescu_Ligia_Lab8.Data;
using Mircescu_Ligia_Lab8.Models;

namespace Mircescu_Ligia_Lab8.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Mircescu_Ligia_Lab8.Data.Mircescu_Ligia_Lab8Context _context;

        public IndexModel(Mircescu_Ligia_Lab8.Data.Mircescu_Ligia_Lab8Context context)
        {
            _context = context;

            //context.Book.Include("PublisherID");
            context.Book.Include(book => book.Publisher.PublisherName);
            

            _context.Book.Include("PublisherID");   //?
            _context.Book.Load();                   //?
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
        }
    }
}
