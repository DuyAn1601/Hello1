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
    public class tiecController : Controller
    {
        private readonly RestaurantContext _context;

        public tiecController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: tiec
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.tiecs.Include(t => t.khachhang);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: tiec/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiecModel = await _context.tiecs
                .Include(t => t.khachhang)
                .FirstOrDefaultAsync(m => m.matiec == id);
            if (tiecModel == null)
            {
                return NotFound();
            }

            return View(tiecModel);
        }

        // GET: tiec/Create
        public IActionResult Create()
        {
            ViewData["makh"] = new SelectList(_context.khachhangs, "makh", "makh");
            return View();
        }

        // POST: tiec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matiec,tentiec,ngaydat,makh")] tiecModel tiecModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiecModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["makh"] = new SelectList(_context.khachhangs, "makh", "makh", tiecModel.makh);
            return View(tiecModel);
        }

        // GET: tiec/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiecModel = await _context.tiecs.FindAsync(id);
            if (tiecModel == null)
            {
                return NotFound();
            }
            ViewData["makh"] = new SelectList(_context.khachhangs, "makh", "makh", tiecModel.makh);
            return View(tiecModel);
        }

        // POST: tiec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matiec,tentiec,ngaydat,makh")] tiecModel tiecModel)
        {
            if (id != tiecModel.matiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiecModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tiecModelExists(tiecModel.matiec))
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
            ViewData["makh"] = new SelectList(_context.khachhangs, "makh", "makh", tiecModel.makh);
            return View(tiecModel);
        }

        // GET: tiec/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiecModel = await _context.tiecs
                .Include(t => t.khachhang)
                .FirstOrDefaultAsync(m => m.matiec == id);
            if (tiecModel == null)
            {
                return NotFound();
            }

            return View(tiecModel);
        }

        // POST: tiec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tiecModel = await _context.tiecs.FindAsync(id);
            _context.tiecs.Remove(tiecModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tiecModelExists(string id)
        {
            return _context.tiecs.Any(e => e.matiec == id);
        }
    }
}
