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
    public class MemberController : Controller
    {
        private readonly LibraryContext _context;

        public MemberController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            return View(await _context.Member.OrderBy(member=>member.MemberId).ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? memberId)
        {
            if (memberId == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DateOfRegistration,Email")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Member.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? memberId)
        {
            if (memberId == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberViewModel model)
        {
             if (ModelState.IsValid)
            {
                var member = _context.Member.Find(model.MemberId);
                if(member==null)
                {
                    return NotFound();
                }
                member.Name = model.Name;
                member.Email = model.Email;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? memberId)
        {
            if (memberId == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int memberId)
        {
            var member = await _context.Member.FindAsync(memberId);
            if (member != null)
            {
                _context.Member.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int memberId)
        {
            return _context.Member.Any(m => m.MemberId == memberId);
        }
    }
}
