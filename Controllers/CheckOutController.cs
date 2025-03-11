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
            ViewData["Members"] = new SelectList(_context.Set<Member>(), "MemberId", "Name");
            ViewData["BookCopy"] = new SelectList(_context.Set<BookCopy>(), "BookCopyId", "BookCopyId");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckOutViewModel checkOutViewModel)
        {           
            var checkout = new CheckOut();
            checkout.BookCopyId = checkOutViewModel.BookCopyId;
            checkout.MemberId = checkOutViewModel.MemberId;
            checkout.CheckoutDate = DateOnly.FromDateTime(DateTime.Now);
            checkout.DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(10);
            checkout.ReturnDate = null;
            _context.CheckOut.Add(checkout);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }


        public IActionResult Return(int checkoutId)
        {
            var checkout = _context.CheckOut.Find(checkoutId);
               
            checkout.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
            _context.SaveChanges();
            return RedirectToAction("Index");
                
        }
    }
}

 