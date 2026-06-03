using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class BaseController : Controller
    {
        protected int idLogeado()
        {
            return HttpContext.Session.GetInt32("id").Value;
        }
        protected bool usuLogeado()
        {
            return HttpContext.Session.GetString("username") != null;
        }
        protected string Rol()
        {
            return HttpContext.Session.GetString("rol");
        }
    }
}
