using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookish.Database;
using Bookish.Models;
using Bookish.ViewModels;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bookish.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly LibraryContext _context;

        public CheckOutController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var checkOuts = await _context.CheckOut
            .Include(checkout => checkout.Member)
            .Include(checkout => checkout.BookCopy)
            .OrderBy(checkout => checkout.CheckoutDate)
            .ToListAsync();
            return View(checkOuts);
        }

        //GET: Checkout/Create
        public IActionResult Create()
        {
            ViewData["Members"] = new SelectList(_context.Set<Member>(), "Name", "Name");
            ViewData["BookTitle"] = new SelectList(_context.Set<Book>(), "Title", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckOutViewModel checkOutViewModel)
        {
            if (ModelState.IsValid)
            {
                var checkout = new CheckOut(checkOutViewModel);
                checkout.CheckoutDate = DateOnly.FromDateTime(DateTime.Now);
                checkout.DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(10);
                checkout.ReturnDate = null;
                _context.CheckOut.Add(checkout);
                
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
           
        }
    }
}

    // var availableBookCopies = _context.BookCopy
    //             .Where(bookcopy => !bookcopy.BookCopyCheckOuts.Any(checkout => checkout.ReturnDate == null))
    //             .ToList();