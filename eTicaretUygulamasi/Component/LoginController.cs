using Microsoft.AspNetCore.Mvc;

namespace eTicaretUygulamasi.Component
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
