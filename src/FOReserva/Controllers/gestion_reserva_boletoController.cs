using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Controllers
{
    public class gestion_reserva_boletoController : Controller
    {
        //
        // GET: /gestion_reserva_boleto/
        public ActionResult busqueda_parametros()
        {
            //System.Diagnostics.Debug.WriteLine("mamalo");
            return PartialView();
        }
        public ActionResult busqueda_resultados()
        {
            return PartialView();
        }
        public ActionResult boleto_datos()
        {
            return PartialView();
        }
        public ActionResult boleto_reserva()
        {
            return PartialView();
        }


    }
}
