using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WADAssignment1.Data;
using WADAssignment1.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WADAssignment1.Controllers
{
	[Authorize(Roles = "Admin,Member")]
	public class NewOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;

		public NewOrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
			_userManager = userManager;
		}

		// GET: NewOrders
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
        {
			return View(await _context.NewOrders.Include(i => i.User).AsNoTracking().ToListAsync());
		}

		//// GET: NewOrders/Details/5
		//public async Task<IActionResult> Details(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var newOrder = await _context.NewOrders.SingleOrDefaultAsync(m => m.ID == id);
		//    if (newOrder == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(newOrder);
		//}

		// GET: NewOrders/Create
		[Authorize(Roles = "Member")]
		public IActionResult Create()
        {
            return View();
        }

		// POST: NewOrders/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Member")]
		public async Task<IActionResult> Create([Bind("City,Country,FirstName,LastName,Phone,PostalCode,State")] NewOrder order)
		{
			ApplicationUser user = await _userManager.GetUserAsync(User);

			if (ModelState.IsValid)
			{

				ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
				List<CartItem> items = cart.GetCartItems(_context);
				List<OrderDetail> details = new List<OrderDetail>();
				foreach (CartItem item in items)
				{

					OrderDetail detail = CreateOrderDetailForThisItem(item);
					detail.NewOrder = order;
					details.Add(detail);
					_context.Add(detail);

				}

				order.User = user;
				order.OrderDate = DateTime.Today;
				order.Total = ShoppingCart.GetCart(this.HttpContext).GetTotal(_context);
				order.OrderDetails = details;
				_context.SaveChanges();


				return RedirectToAction("Purchased", new RouteValueDictionary(
				new { action = "Purchased", id = order.ID }));
			}

			return View(order);
		}

		private OrderDetail CreateOrderDetailForThisItem(CartItem item)
		{

			OrderDetail detail = new OrderDetail();


			detail.Quantity = item.Count;
			detail.Bag = item.Bag;
			detail.UnitPrice = (decimal)item.Bag.Price;

			return detail;

		}
		public async Task<IActionResult> Purchased(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var order = await _context.NewOrders.Include(i => i.User).AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
			if (order == null)
			{
				return NotFound();
			}

			var details = _context.OrderDetails.Where(detail => detail.NewOrder.ID == order.ID).Include(detail => detail.Bag).ToList();

			order.OrderDetails = details;
			ShoppingCart.GetCart(this.HttpContext).EmptyCart(_context);
			return View(order);
		}

		//// GET: NewOrders/Edit/5
		//public async Task<IActionResult> Edit(int? id)
		//      {
		//          if (id == null)
		//          {
		//              return NotFound();
		//          }

		//          var newOrder = await _context.NewOrders.SingleOrDefaultAsync(m => m.ID == id);
		//          if (newOrder == null)
		//          {
		//              return NotFound();
		//          }
		//          return View(newOrder);
		//      }

		//      // POST: NewOrders/Edit/5
		//      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//      [HttpPost]
		//      [ValidateAntiForgeryToken]
		//      public async Task<IActionResult> Edit(int id, [Bind("ID,City,Country,FirstName,LastName,OrderDate,Phone,PostalCode,State,Total")] NewOrder newOrder)
		//      {
		//          if (id != newOrder.ID)
		//          {
		//              return NotFound();
		//          }

		//          if (ModelState.IsValid)
		//          {
		//              try
		//              {
		//                  _context.Update(newOrder);
		//                  await _context.SaveChangesAsync();
		//              }
		//              catch (DbUpdateConcurrencyException)
		//              {
		//                  if (!NewOrderExists(newOrder.ID))
		//                  {
		//                      return NotFound();
		//                  }
		//                  else
		//                  {
		//                      throw;
		//                  }
		//              }
		//              return RedirectToAction("Index");
		//          }
		//          return View(newOrder);
		//      }

		// GET: NewOrders/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var order = await _context.NewOrders.Include(i => i.User).AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);

			if (order == null)
            {
                return NotFound();
            }

			var details = _context.OrderDetails.Where(detail => detail.NewOrder.ID == order.ID).Include(detail => detail.Bag).ToList();

			order.OrderDetails = details;

			return View(order);
        }

        // POST: NewOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newOrder = await _context.NewOrders.SingleOrDefaultAsync(m => m.ID == id);
            _context.NewOrders.Remove(newOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //private bool NewOrderExists(int id)
        //{
        //    return _context.NewOrders.Any(e => e.ID == id);
        //}
    }
}
