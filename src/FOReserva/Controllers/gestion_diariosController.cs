using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Diarios;
using FOReserva.Servicio;

namespace FOReserva.Controllers
{
    public class gestion_diariosController : Controller
    {
        //
        // GET: /gestion_diarios/


        public ActionResult gestion_diarios()
        {
            CDiarioModel model = new CDiarioModel();
            return PartialView(model);
            
        }

        public ActionResult gestion_diariosImagenes()
        {            
            return PartialView();
        }

        public ActionResult gestion_diarios_resultados()
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CDiarioModel> lista = manejador.obtenerDiarios();
            return PartialView(lista);
        }
                
        [HttpPost]
        public JsonResult buscarDiarios(CDiarioModel model)
        {
    
            String nombre = model.Nombre;
            DateTime f_inicio = model.Fecha_ini;
            DateTime f_fin = model.Fecha_fin;
            int fk_lugar = model.Lugar;

            return (Json("asdf", JsonRequestBehavior.AllowGet));
        }

    }
}
