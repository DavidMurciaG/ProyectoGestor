using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGestor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Controllers
{
    public class LocalitiesController : Controller
    {
        private readonly AppDbContext _context;

        public LocalitiesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Localities.Include(l => l.Province);
            return View(await context.ToListAsync());
        }
    }
}
