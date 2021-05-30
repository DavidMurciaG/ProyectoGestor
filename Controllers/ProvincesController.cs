using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGestor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProyectoGestor.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly AppDbContext _context;
        public ProvincesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provinces.ToListAsync());
        }
    }
}
