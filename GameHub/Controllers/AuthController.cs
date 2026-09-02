using Microsoft.AspNetCore.Mvc;

namespace YourProject.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login() => View();
        public IActionResult Register() => View();
    }
}