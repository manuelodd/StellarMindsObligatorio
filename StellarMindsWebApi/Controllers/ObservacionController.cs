using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebApi.Controllers
{
    public class ObservacionController : Controller
    {
        private IListarPrestamosSocio listarPrestamosSocioCU;
        private IListarObjetosCelestes listarObjetosCelestesCU;
        private IAltaObservacion altaObservacionCU;
        private IRankObjetosCelestes rankObjetosCelestesCU;

        public ObservacionController(IListarPrestamosSocio listPresSocioCu,
                                     IListarObjetosCelestes listarObjetosCelestesCu,
                                     IRankObjetosCelestes rankObjetosCelestesCu,
                                     IAltaObservacion altaObservacionCu)
        {
            this.listarPrestamosSocioCU = listPresSocioCu;
            this.listarObjetosCelestesCU = listarObjetosCelestesCu;
            this.altaObservacionCU = altaObservacionCu;
            this.rankObjetosCelestesCU = rankObjetosCelestesCu;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
