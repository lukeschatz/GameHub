using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;

namespace GameHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var activeOrders = _context.Orders
                .Include(o => o.User)
                .Where(o => !o.Sold);

            var latest = await activeOrders
                .OrderByDescending(o => o.CreatedAt)
                .Take(4)
                .ToListAsync();

            var oldest = await activeOrders
                .OrderBy(o => o.CreatedAt)
                .Take(4)
                .ToListAsync();

            return View((Latest: latest, Oldest: oldest));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
