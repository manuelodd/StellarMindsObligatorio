using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace StellarMindsWebAPP.Controllers
{
    public class PrestamoController : BaseController
    {





        // GET: PrestamoController/Create


        /*
        public ActionResult Return(int id)
        {
            returnCU.Execute(id);
            return RedirectToAction(nameof(Index));
        }
        */

        // GET: PrestamoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestamoController/Edit/5
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

        // GET: PrestamoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestamoController/Delete/5
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
