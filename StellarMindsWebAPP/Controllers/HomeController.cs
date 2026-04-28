using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;
using StellarMindsWebAPP.Models;
using System.Diagnostics;

namespace StellarMindsWebAPP.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
