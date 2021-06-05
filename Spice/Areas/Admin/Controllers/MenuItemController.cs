using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Spice.Data;
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
        public MenuItemController(ApplicationDbContext db, IHostingEnvironment hostingEnviornment)
        {
            _db = db;
            _hostingEnviornment = hostingEnviornment;
        }
        public async Task <IActionResult> Index()
        {
            var menuItem = await _db.MenuItem.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View();
        }
    }
}
