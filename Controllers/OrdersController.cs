using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGestor.Data;
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
    }
}
