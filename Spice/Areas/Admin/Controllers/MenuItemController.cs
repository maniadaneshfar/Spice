using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Spice.Data;
using Spice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnviornment;
        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }
        public MenuItemController(ApplicationDbContext db, IHostingEnvironment hostingEnviornment)
        {
            _db = db;
            _hostingEnviornment = hostingEnviornment;
            MenuItemVM = new MenuItemViewModel()
            {
                Category = _db.Category,
                MenuItem = new Models.MenuItem()
            };
        }
        public async Task <IActionResult> Index()
        {
            var menuItems = await _db.MenuItem.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View(menuItems);
        }
        //GET-Creat
        public IActionResult Create()
        {
            return View(MenuItemVM);
        }
    }
}
