using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGestor.Data;
using ProyectoGestor.Models.LocalityStatViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Controllers
{
    [Authorize]
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

        public async Task<ActionResult> Stat()
        {
            IQueryable<LocalityClientGroup> data =
        from Client in _context.Clients
        group Client by Client.Locality.Name into LocalityGroup
        select new LocalityClientGroup()
        {
            Name = LocalityGroup.Key,
            ClientCount = LocalityGroup.Count()
        };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}
