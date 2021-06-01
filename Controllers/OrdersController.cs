using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoGestor.Data;
using ProyectoGestor.Models;
using ProyectoGestor.Models.OrderProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        /*public async Task<IActionResult> Index()
        {
            //var context = _context.Orders.Include(o => o.Client).Include(o => o.ProductID);
            // View(await context.ToListAsync());
            
        }*/
        public async Task<IActionResult> Index(int? id, int? productID)
        {
            var viewModel = new OrderIndexData();
            viewModel.Orders = await _context.Orders
                  .Include(i => i.OrderProduct)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(i => i.ProductCategory)
                  .Include(i => i.Client)
                  .AsNoTracking()
                  .ToListAsync();

            if (id != null)
            {
                ViewData["OrderID"] = id.Value;
                Order order = viewModel.Orders.Where(
                    i => i.OrderID == id.Value).Single();
                viewModel.Products = order.OrderProduct.Select(s => s.Product);
            }
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var order = new Order();
            order.OrderProduct = new List<OrderProduct>();
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ID");
            PopulateAssignedProductData(order);
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Date,ClientID,ProductOrder")] Order order, string[] selectedProducts)
        {
            if (selectedProducts != null)
            {
                order.OrderProduct = new List<OrderProduct>();
                foreach (var product in selectedProducts)
                {
                    var productToAdd = new OrderProduct { OrderID = order.OrderID, ProductID = int.Parse(product) };
                    order.OrderProduct.Add(productToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedProductData(order);
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(i => i.OrderProduct)
                .ThenInclude(i => i.Product)
                .Include(i => i.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            //idea 
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ID", order.ClientID);

            PopulateAssignedProductData(order);
            return View(order);
        }

        private void PopulateAssignedProductData(Order order)
        {
            var allProducts = _context.Products;
            var orderProducts = new HashSet<int>(order.OrderProduct.Select(c => c.ProductID));
            var viewModel = new List<AssignedProductData>();
            foreach (var product in allProducts)
            {
                viewModel.Add(new AssignedProductData
                {
                    ID = product.ID,
                    Name = product.Name,
                    Assigned = orderProducts.Contains(product.ID)
                });
            }
            ViewData["Products"] = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedProducts)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToUpdate = await _context.Orders
                .Include(i => i.Client)
                .Include(i => i.OrderProduct)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (await TryUpdateModelAsync<Order>(
                orderToUpdate,
                "",
                i => i.OrderID, i => i.Date, i => i.ClientID))
            {
                UpdateOrderProducts(selectedProducts, orderToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateOrderProducts(selectedProducts, orderToUpdate);
            PopulateAssignedProductData(orderToUpdate);
            return View(orderToUpdate);
        }

        private void UpdateOrderProducts(string[] selectedProducts, Order orderToUpdate)
        {
            if (selectedProducts == null)
            {
                orderToUpdate.OrderProduct = new List<OrderProduct>();
                return;
            }

            var selectedProductsHS = new HashSet<string>(selectedProducts);
            var orderProducts = new HashSet<int>
                (orderToUpdate.OrderProduct.Select(c => c.Product.ID));
            foreach (var product in _context.Products)
            {
                if (selectedProductsHS.Contains(product.ID.ToString()))
                {
                    if (!orderProducts.Contains(product.ID))
                    {
                        orderToUpdate.OrderProduct.Add(new OrderProduct { OrderID = orderToUpdate.OrderID, ProductID = product.ID });
                    }
                }
                else
                {

                    if (orderProducts.Contains(product.ID))
                    {
                        OrderProduct productToRemove = orderToUpdate.OrderProduct.FirstOrDefault(i => i.ProductID == product.ID);
                        _context.Remove(productToRemove);
                    }
                }
            }
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Order order = await _context.Orders
                    .Include(i => i.OrderProduct)
                    .Include(i => i.Client)
                    .SingleAsync(i => i.OrderID == id);

                _context.Orders.Remove(order);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message + " No se pueden borrar pedidos con productos dentro.";
                return View("NotFound");
            }

        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
