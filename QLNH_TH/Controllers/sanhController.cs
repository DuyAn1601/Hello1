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
    public class sanhController : Controller
    {
        private readonly RestaurantContext _context;

        public sanhController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: sanh
        public async Task<IActionResult> Index()
        {
            return View(await _context.sanhs.ToListAsync());
        }

        // GET: sanh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanhModel = await _context.sanhs
                .FirstOrDefaultAsync(m => m.masanh == id);
            if (sanhModel == null)
            {
                return NotFound();
            }

            return View(sanhModel);
        }

        // GET: sanh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("masanh,tenSanh")] sanhModel sanhModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanhModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanhModel);
        }

        // GET: sanh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanhModel = await _context.sanhs.FindAsync(id);
            if (sanhModel == null)
            {
                return NotFound();
            }
            return View(sanhModel);
        }

        // POST: sanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("masanh,tenSanh")] sanhModel sanhModel)
        {
            if (id != sanhModel.masanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanhModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sanhModelExists(sanhModel.masanh))
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
            return View(sanhModel);
        }

        // GET: sanh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanhModel = await _context.sanhs
                .FirstOrDefaultAsync(m => m.masanh == id);
            if (sanhModel == null)
            {
                return NotFound();
            }

            return View(sanhModel);
        }

        // POST: sanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanhModel = await _context.sanhs.FindAsync(id);
            _context.sanhs.Remove(sanhModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sanhModelExists(string id)
        {
            return _context.sanhs.Any(e => e.masanh == id);
        }
    }
}
