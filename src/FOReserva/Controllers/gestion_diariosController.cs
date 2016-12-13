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

        /* Carga la página principal */
        public ActionResult gestion_diarios()
        {
            CDiarioModel model = new CDiarioModel();
            return PartialView(model);
            
        }

        /* Carga la seccion lateral derecha */
        public ActionResult gestion_diariosImagenes()
        {            
            return PartialView();
        }

        /* Carga todos los resultados */
        [HttpGet]
        public ActionResult gestion_diarios_resultados()
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CDiarioModel> lista = manejador.obtenerDiarios();
            return PartialView(lista);
        }

        /* Carga los resultados por búsqueda */
        [HttpPost]
        public ActionResult gestion_diarios_resultados(CDiarioModel model)
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CDiarioModel> lista = manejador.buscarDiarios(model);
            return PartialView(lista);
        }

        /* Carga la vista de un diario */
        [HttpPost]
        public ActionResult gestion_diarios_ver(int id_diario)
        {
            CDiarioModel model;
            ManejadorSQLDiarios man = new ManejadorSQLDiarios();
            model = man.buscarDiarios(id_diario);
            return PartialView(model);
        }

        /* Carga la vista de creación */
        [HttpGet]
        public ActionResult gestion_diarios_crear()
        {
            CDiarioModel model = new CDiarioModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult gestion_diarios_insertar(CDiarioModel nuevo_diario)
        {
            ManejadorSQLDiarios man = new ManejadorSQLDiarios();
            int id_nuevo = man.CrearDiario(nuevo_diario);             
            if(id_nuevo != -1){
                return PartialView("_CrearDiarioExito");
            }
            return PartialView("_CrearDiarioError");
        }
                
    }
}