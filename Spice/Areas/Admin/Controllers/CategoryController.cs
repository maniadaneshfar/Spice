using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET Category table from Database
        public async Task<IActionResult> Index()
        {
            return View(await _db.Category.ToListAsync());
        }
        //GET   - Create
        public IActionResult Create()
        {
            return View();
        }

        //Post  - Create
            //  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.Category.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(category);
        }


        //Action methode for GET (Edit)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var category = await _db.Category.FindAsync(id);
            if (category==null)
            {
                return NotFound();

            }
            return View(category);
        }
    }
}
