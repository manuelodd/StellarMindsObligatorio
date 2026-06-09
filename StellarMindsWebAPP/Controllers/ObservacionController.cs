
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class ObservacionController : BaseController
    {



        // GET: ObservacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ObservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: ObservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ObservacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ObservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ObservacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
