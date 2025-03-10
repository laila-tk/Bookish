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

        // GET: BookCopy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCopy = await _context.BookCopy
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.CopyId == id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            return View(bookCopy);
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
            Console.WriteLine("Number of copies : " + bookCopyViewModel.NumberOfCopies);
            for(int i=0; i < bookCopyViewModel.NumberOfCopies; i++) {
                Console.WriteLine("inside for");
                BookCopy copy = new BookCopy(bookCopyViewModel);
                _context.BookCopy.Add(copy);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: BookCopy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCopy = await _context.BookCopy.FindAsync(id);
            if (bookCopy == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Set<Book>(), "BookId", "BookId", bookCopy.BookId);
            return View(bookCopy);
        }

        // POST: BookCopy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CopyId,BookId")] BookCopy bookCopy)
        {
            if (id != bookCopy.CopyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCopy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCopyExists(bookCopy.CopyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Set<Book>(), "BookId", "BookId", bookCopy.BookId);
            return View(bookCopy);
        }

        // GET: BookCopy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCopy = await _context.BookCopy
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.CopyId == id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            return View(bookCopy);
        }

        // POST: BookCopy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCopy = await _context.BookCopy.FindAsync(id);
            if (bookCopy != null)
            {
                _context.BookCopy.Remove(bookCopy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCopyExists(int id)
        {
            return _context.BookCopy.Any(e => e.CopyId == id);
        }
    }
}
