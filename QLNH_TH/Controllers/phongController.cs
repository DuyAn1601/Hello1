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
    public class phongController : Controller
    {
        private readonly RestaurantContext _context;

        public phongController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: phong
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.phongs.Include(p => p.sanh);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: phong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.phongs
                .Include(p => p.sanh)
                .FirstOrDefaultAsync(m => m.maphong == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // GET: phong/Create
        public IActionResult Create()
        {
            ViewData["masanh"] = new SelectList(_context.sanhs, "masanh", "masanh");
            return View();
        }

        // POST: phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maphong,tenphong,succhua,loaiphong,masanh")] phongModel phongModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["masanh"] = new SelectList(_context.sanhs, "masanh", "masanh", phongModel.masanh);
            return View(phongModel);
        }

        // GET: phong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.phongs.FindAsync(id);
            if (phongModel == null)
            {
                return NotFound();
            }
            ViewData["masanh"] = new SelectList(_context.sanhs, "masanh", "masanh", phongModel.masanh);
            return View(phongModel);
        }

        // POST: phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maphong,tenphong,succhua,loaiphong,masanh")] phongModel phongModel)
        {
            if (id != phongModel.maphong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!phongModelExists(phongModel.maphong))
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
            ViewData["masanh"] = new SelectList(_context.sanhs, "masanh", "masanh", phongModel.masanh);
            return View(phongModel);
        }

        // GET: phong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.phongs
                .Include(p => p.sanh)
                .FirstOrDefaultAsync(m => m.maphong == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // POST: phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phongModel = await _context.phongs.FindAsync(id);
            _context.phongs.Remove(phongModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool phongModelExists(string id)
        {
            return _context.phongs.Any(e => e.maphong == id);
        }
    }
}
