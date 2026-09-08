using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameHub.Data;

namespace GameHub.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PageSize = 16;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? q, int page = 1)
        {
            if (page < 1) page = 1;

            var query = _context.Orders
                .Include(o => o.User)
                .Where(o => !o.Sold);

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(o => o.Title.Contains(q));
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            if (totalPages > 0 && page > totalPages) page = totalPages;

            var results = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            ViewBag.CurrentQuery = q;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(results);
        }
    }
}