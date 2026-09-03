using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameHub.Data;

namespace GameHub.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? q)
        {
            var query = _context.Orders
                .Include(o => o.User)
                .Where(o => !o.Sold);

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(o => o.Title.Contains(q));
            }

            ViewBag.CurrentQuery = q;
            var results = await query.OrderByDescending(o => o.CreatedAt).ToListAsync();

            return View(results);
        }
    }
}