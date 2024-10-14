using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class MoodEntriesController : Controller
    {
        private readonly CookieContext _context;

        public MoodEntriesController(CookieContext context)
        {
            _context = context;
        }

        // GET: MoodEntries
        public async Task<IActionResult> Index()
        {
            var cookieContext = _context.MoodEntries.Include(m => m.Members);
            return View(await cookieContext.ToListAsync());
        }

        // GET: MoodEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoodEntries == null)
            {
                return NotFound();
            }

            var moodEntry = await _context.MoodEntries
                .Include(m => m.Members)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moodEntry == null)
            {
                return NotFound();
            }

            return View(moodEntry);
        }

        // GET: MoodEntries/Create
        public IActionResult Create()
        {
            ViewData["MembersId"] = new SelectList(_context.Membership, "Id", "Email");
            return View();
        }

        // POST: MoodEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntryDate,Mood,Notes,MembersId")] MoodEntry moodEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moodEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembersId"] = new SelectList(_context.Membership, "Id", "Email", moodEntry.MembersId);
            return View(moodEntry);
        }

        // GET: MoodEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoodEntries == null)
            {
                return NotFound();
            }

            var moodEntry = await _context.MoodEntries.FindAsync(id);
            if (moodEntry == null)
            {
                return NotFound();
            }
            ViewData["MembersId"] = new SelectList(_context.Membership, "Id", "Email", moodEntry.MembersId);
            return View(moodEntry);
        }

        // POST: MoodEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntryDate,Mood,Notes,MembersId")] MoodEntry moodEntry)
        {
            if (id != moodEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moodEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoodEntryExists(moodEntry.Id))
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
            ViewData["MembersId"] = new SelectList(_context.Membership, "Id", "Email", moodEntry.MembersId);
            return View(moodEntry);
        }

        // GET: MoodEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoodEntries == null)
            {
                return NotFound();
            }

            var moodEntry = await _context.MoodEntries
                .Include(m => m.Members)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moodEntry == null)
            {
                return NotFound();
            }

            return View(moodEntry);
        }

        // POST: MoodEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoodEntries == null)
            {
                return Problem("Entity set 'CookieContext.MoodEntries'  is null.");
            }
            var moodEntry = await _context.MoodEntries.FindAsync(id);
            if (moodEntry != null)
            {
                _context.MoodEntries.Remove(moodEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoodEntryExists(int id)
        {
          return (_context.MoodEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
