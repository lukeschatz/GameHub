using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameHub.Data;

namespace GameHub.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PurchaseController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            var currentUserId = _userManager.GetUserId(User);

            if (order.Sold && order.BuyerId != currentUserId && order.UserId != currentUserId)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Login", "Auth");

            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            if (order.Sold)
            {
                TempData["ErrorMessage"] = "This item has been Sold!";
                return RedirectToAction("Index", new { id });
            }

            if (order.UserId == userId)
            {
                TempData["ErrorMessage"] = "You cant purchase your own accounts!";
                return RedirectToAction("Index", new { id });
            }

            order.Sold = true;
            order.BuyerId = userId;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Purchase completed, check your account orders!";
            return RedirectToAction("Index", new { id });
        }
    }
}