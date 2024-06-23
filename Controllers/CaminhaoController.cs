using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.SmartWasteManagement.Controllers
{
    public class CaminhaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
