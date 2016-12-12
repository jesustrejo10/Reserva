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

        [HttpGet]
        public ActionResult gestion_diarios_resultados()
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CDiarioModel> lista = manejador.obtenerDiarios();
            return PartialView(lista);
        }

        [HttpPost]
        public ActionResult gestion_diarios_resultados(CDiarioModel model)
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CDiarioModel> lista = manejador.buscarDiarios(model);
            return PartialView(lista);
        }
                
    }
}
