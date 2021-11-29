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
    public class khachhangController : Controller
    {
        private readonly RestaurantContext _context;

        public khachhangController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: khachhang
        public async Task<IActionResult> Index()
        {
            return View(await _context.khachhangs.ToListAsync());
        }

        // GET: khachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhangModel = await _context.khachhangs
                .FirstOrDefaultAsync(m => m.makh == id);
            if (khachhangModel == null)
            {
                return NotFound();
            }

            return View(khachhangModel);
        }

        // GET: khachhang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("makh,tenk,ngaysinh,diachi")] khachhangModel khachhangModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhangModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhangModel);
        }

        // GET: khachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhangModel = await _context.khachhangs.FindAsync(id);
            if (khachhangModel == null)
            {
                return NotFound();
            }
            return View(khachhangModel);
        }

        // POST: khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("makh,tenk,ngaysinh,diachi")] khachhangModel khachhangModel)
        {
            if (id != khachhangModel.makh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhangModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!khachhangModelExists(khachhangModel.makh))
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
            return View(khachhangModel);
        }

        // GET: khachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhangModel = await _context.khachhangs
                .FirstOrDefaultAsync(m => m.makh == id);
            if (khachhangModel == null)
            {
                return NotFound();
            }

            return View(khachhangModel);
        }

        // POST: khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khachhangModel = await _context.khachhangs.FindAsync(id);
            _context.khachhangs.Remove(khachhangModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool khachhangModelExists(string id)
        {
            return _context.khachhangs.Any(e => e.makh == id);
        }
    }
}
