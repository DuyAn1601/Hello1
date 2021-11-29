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
    public class nhanvienController : Controller
    {
        private readonly RestaurantContext _context;

        public nhanvienController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: nhanvien
        public async Task<IActionResult> Index()
        {
            return View(await _context.nhanviens.ToListAsync());
        }

        // GET: nhanvien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvienModel = await _context.nhanviens
                .FirstOrDefaultAsync(m => m.manv == id);
            if (nhanvienModel == null)
            {
                return NotFound();
            }

            return View(nhanvienModel);
        }

        // GET: nhanvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("manv,tennv,gioitinh,ngaysinh")] nhanvienModel nhanvienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvienModel);
        }

        // GET: nhanvien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvienModel = await _context.nhanviens.FindAsync(id);
            if (nhanvienModel == null)
            {
                return NotFound();
            }
            return View(nhanvienModel);
        }

        // POST: nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("manv,tennv,gioitinh,ngaysinh")] nhanvienModel nhanvienModel)
        {
            if (id != nhanvienModel.manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nhanvienModelExists(nhanvienModel.manv))
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
            return View(nhanvienModel);
        }

        // GET: nhanvien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvienModel = await _context.nhanviens
                .FirstOrDefaultAsync(m => m.manv == id);
            if (nhanvienModel == null)
            {
                return NotFound();
            }

            return View(nhanvienModel);
        }

        // POST: nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvienModel = await _context.nhanviens.FindAsync(id);
            _context.nhanviens.Remove(nhanvienModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nhanvienModelExists(int id)
        {
            return _context.nhanviens.Any(e => e.manv == id);
        }
    }
}
