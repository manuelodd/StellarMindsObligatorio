
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace StellarMindsWebAPP.Controllers
{
    public class EquipoController : Controller
    {
        


        // GET: EquipoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // - - - - - - - - - - - - - - - - - - - - - - - - -  EDITS - - - - - - - - - - - - - - - - - -  - - - - - -  - - - - -  - - -
 



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

        

        // POST: EquipoController/Delete/5
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
