using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNH_TH.Data;
using QLNH_TH.Models;

namespace QLNH_TH.Controllers
{
    public class bookphongController : Controller
    {
        private readonly RestaurantContext _context;

        public bookphongController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: bookphong
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.bookphongs.Include(b => b.phong).Include(b => b.tiec);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: bookphong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookphongModel = await _context.bookphongs
                .Include(b => b.phong)
                .Include(b => b.tiec)
                .FirstOrDefaultAsync(m => m.matiec == id);
            if (bookphongModel == null)
            {
                return NotFound();
            }

            return View(bookphongModel);
        }

        // GET: bookphong/Create
        public IActionResult Create()
        {
            ViewData["maphong"] = new SelectList(_context.phongs, "maphong", "maphong");
            ViewData["matiec"] = new SelectList(_context.tiecs, "matiec", "matiec");
            return View();
        }

        // POST: bookphong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matiec,maphong,soLuongNuocUong")] bookphongModel bookphongModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookphongModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maphong"] = new SelectList(_context.phongs, "maphong", "maphong", bookphongModel.maphong);
            ViewData["matiec"] = new SelectList(_context.tiecs, "matiec", "matiec", bookphongModel.matiec);
            return View(bookphongModel);
        }

        // GET: bookphong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookphongModel = await _context.bookphongs.FindAsync(id);
            if (bookphongModel == null)
            {
                return NotFound();
            }
            ViewData["maphong"] = new SelectList(_context.phongs, "maphong", "maphong", bookphongModel.maphong);
            ViewData["matiec"] = new SelectList(_context.tiecs, "matiec", "matiec", bookphongModel.matiec);
            return View(bookphongModel);
        }

        // POST: bookphong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matiec,maphong,soLuongNuocUong")] bookphongModel bookphongModel)
        {
            if (id != bookphongModel.matiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookphongModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bookphongModelExists(bookphongModel.matiec))
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
            ViewData["maphong"] = new SelectList(_context.phongs, "maphong", "maphong", bookphongModel.maphong);
            ViewData["matiec"] = new SelectList(_context.tiecs, "matiec", "matiec", bookphongModel.matiec);
            return View(bookphongModel);
        }

        // GET: bookphong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookphongModel = await _context.bookphongs
                .Include(b => b.phong)
                .Include(b => b.tiec)
                .FirstOrDefaultAsync(m => m.matiec == id);
            if (bookphongModel == null)
            {
                return NotFound();
            }

            return View(bookphongModel);
        }

        // POST: bookphong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bookphongModel = await _context.bookphongs.FindAsync(id);
            _context.bookphongs.Remove(bookphongModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bookphongModelExists(string id)
        {
            return _context.bookphongs.Any(e => e.matiec == id);
        }
    }
}
