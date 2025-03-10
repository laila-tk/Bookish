using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookish.Database;
using Bookish.Models;
using Bookish.ViewModels;

namespace Bookish.Controllers
{
    public class BookCopyController : Controller
    {
        private readonly LibraryContext _context;

        public BookCopyController(LibraryContext context)
        {
            _context = context;
        }

        // GET: BookCopy
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookCopy.Include(b => b.Book).ToListAsync());
        }
        
        // GET: BookCopy/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Set<Book>(), "BookId", "BookId");
            return View();
        }

        // POST: BookCopy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCopyViewModel bookCopyViewModel)
        {   
            for(int i=0; i < bookCopyViewModel.NumberOfCopies; i++) {
                BookCopy copy = new BookCopy(bookCopyViewModel);
                _context.BookCopy.Add(copy);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCopyExists(int id)
        {
            return _context.BookCopy.Any(e => e.BookCopyId == id);
        }
    }
}
