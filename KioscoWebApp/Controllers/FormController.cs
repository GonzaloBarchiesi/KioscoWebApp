using Microsoft.AspNetCore.Mvc;

namespace KioscoWebApp.Controllers
{
    public class FormController : Controller
    {
        public FormController()
        {
            
        }
        public IActionResult Opiniones()
        {
            return View();
        }
    }
}
