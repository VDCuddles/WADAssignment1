using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WADAssignment1.Data;
using WADAssignment1.Models;
using Microsoft.AspNetCore.Authorization;

namespace WADAssignment1.Controllers
{
	[Authorize(Roles = "Admin")]
	public class BagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BagsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Bags
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bags.ToListAsync());
        }

		// GET: Bags/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var student = await _context.Bags
			//.Include(s => s.SupplierID)
			.AsNoTracking()
			.SingleOrDefaultAsync(m => m.ID == id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}


		// GET: Bags/Create
		public IActionResult Create()
        {
            return View();
        }

        // POST: Bags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CategoryName,Description,Image,Name,Price,SupplierID")] Bag bag)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_context.Add(bag);
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
			catch (DbUpdateException /* ex */)
			{
				//Log the error (uncomment ex variable name and write a log.
				ModelState.AddModelError("", "Unable to save changes. " +
				"Try again, and if the problem persists " +
				"see your system administrator.");
			}
			return View(bag);
		}


		// GET: Bags/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags.SingleOrDefaultAsync(m => m.ID == id);
            if (bag == null)
            {
                return NotFound();
            }
            return View(bag);
        }

		// POST: Bags/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditPost(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var bagToUpdate = await _context.Bags.SingleOrDefaultAsync(s => s.ID == id);
			if (await TryUpdateModelAsync<Bag>(
			bagToUpdate,
			"",
			s => s.SupplierID, s => s.Name, s => s.CategoryName, s => s.Description, s => s.Image, s => s.Price))
			{
				try
				{
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				catch (DbUpdateException /* ex */)
				{
					//Log the error (uncomment ex variable name and write a log.)
					ModelState.AddModelError("", "Unable to save changes. " +
					"Try again, and if the problem persists, " +
					"see your system administrator.");
				}
			}
			return View(bagToUpdate);
		}


		// GET: Bags/Delete/5
		public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
		{
			if (id == null)
			{
				return NotFound();
			}
			var bag = await _context.Bags
			.AsNoTracking()
			.SingleOrDefaultAsync(m => m.ID == id);
			if (bag == null)
			{
				return NotFound();
			}
			if (saveChangesError.GetValueOrDefault())
			{
				ViewData["ErrorMessage"] =
				"Delete failed. Try again, and if the problem persists " +
				"see your system administrator.";
			}
			return View(bag);
		}


		// POST: Bags/Delete/5
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bag = await _context.Bags.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bags.Remove(bag);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException s)
			{
				TempData["BagUsed"] = "The Bag being deleted has been used in previous orders.Delete those orders before trying again.";
				return RedirectToAction("Delete");
			}

			await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BagExists(int id)
        {
            return _context.Bags.Any(e => e.ID == id);
        }
    }
}
