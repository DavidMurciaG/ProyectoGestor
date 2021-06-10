using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoGestor.Data;
using ProyectoGestor.Models;
using ProyectoGestor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        /*public async Task<IActionResult> Index()
        {
            var context = _context.Clients.Include(c => c.Locality);
            return View(await context.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string sortOrdenation, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrdenation;
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrdenation) ? "LastName_desc" : "";
            ViewData["NameSortParm"] = sortOrdenation == "Name" ? "Name_desc" : "Name";
            ViewData["EmailSortParm"] = sortOrdenation == "Email" ? "Email_desc" : "Email";
            ViewData["PhoneNumberSortParm"] = sortOrdenation == "PhoneNumber" ? "PhoneNumber_desc" : "PhoneNumber";
            ViewData["CIFSortParm"] = sortOrdenation == "CIF" ? "CIF_desc" : "CIF";
            ViewData["AddressSortParm"] = sortOrdenation == "Address" ? "Address_desc" : "Address";
            ViewData["LocalityIDSortParm"] = sortOrdenation == "LocalityID" ? "LocalityID_desc" : "LocalityID";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var clients = from c in _context.Clients.Include(i => i.Locality)
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.LastName.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }
            switch (sortOrdenation)
            {
                case "LastName_desc":
                    clients = clients.OrderByDescending(s => s.LastName);
                    break;
                case "Name":
                    clients = clients.OrderBy(c => c.Name);
                    break;
                case "Name_desc":
                    clients = clients.OrderByDescending(c => c.Name);
                    break;
                case "Email":
                    clients = clients.OrderBy(c => c.Email);
                    break;
                case "Email_desc":
                    clients = clients.OrderByDescending(c => c.Email);
                    break;
                case "PhoneNumber":
                    clients = clients.OrderBy(c => c.PhoneNumber);
                    break;
                case "PhoneNumber_desc":
                    clients = clients.OrderByDescending(c => c.PhoneNumber);
                    break;
                case "CIF":
                    clients = clients.OrderBy(c => c.CIF);
                    break;
                case "CIF_desc":
                    clients = clients.OrderByDescending(c => c.CIF);
                    break;
                case "Address":
                    clients = clients.OrderBy(c => c.Address);
                    break;
                case "Address_desc":
                    clients = clients.OrderByDescending(c => c.Address);
                    break;
                case "LocalityID":
                    clients = clients.OrderBy(c => c.Locality.Name);
                    break;
                case "LocalityID_desc":
                    clients = clients.OrderByDescending(c => c.Locality.Name);
                    break;
                default:
                    clients = clients.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Client>.CreateAsync(clients.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await clients.AsNoTracking().ToListAsync());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,LastName,Email,PhoneNumber,CIF,Address,LocalityID")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalityID"] = new SelectList(_context.Localities, "ID", "ID", client.LocalityID);
            //PopulateLocalitiesDropDownList(client.LocalityID);
            return View(client);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var client = await _context.Clients.FindAsync(id);
            var client = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["LocalityID"] = new SelectList(_context.Localities, "ID", "ID", client.LocalityID);
            //PopulateLocalitiesDropDownList(client.LocalityID);
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,LastName,Email,PhoneNumber,CIF,Address,LocalityID")] Client client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
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
            ViewData["LocalityID"] = new SelectList(_context.Localities, "ID", "ID", client.LocalityID);
            //PopulateLocalitiesDropDownList(client.LocalityID);
            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Locality)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }

    }
}
