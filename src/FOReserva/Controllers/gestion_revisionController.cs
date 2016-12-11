using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Restaurantes;

namespace FORevision.Controllers
{
    /// <summary>
    /// Gestion Revision Controlador
    /// </summary>
    public class gestion_revisionController : Controller
    {
       

        /// <summary>
        /// Creacion Modelo Lista Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
     /*   public ActionResult Consultar_Revision(string usuario)
        {
            // int search_val = Int32.Parse(Request.QueryString["search_val"]);
            // string Usuario = Request.QueryString["Usuario"];

            //List<CRevision> lista;
            //ManejadorSQLRevision manejador = new ManejadorSQLRevision();

            CRevision modelo = new CRevision();
            return PartialView(modelo);
        }
      * 
      * */

        /// <summary>
        /// Creacion Modelo Lista Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Consultar_Revision_Usuario(string nombre , string apellido)
        {
        
            List<CRevision> lista;
            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
            lista = manejador.ConsultarRevision(nombre, apellido);

            return PartialView(lista);
        }

        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
       /* public ActionResult Eliminar_Revision(string nombre, string apellido,  int revision)
        {
            List<CRevision> lista;
            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision(); 
            lista = manejador.Eliminar_Revision(nombre, apellido, revision);

            return PartialView(lista);
        }
        * 
        * */

        /// <summary>
        /// Creacion Modelo Lista Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Eliminar_Revision(string nombre, string apellido, int revision)
        {
           
           

                CRevision Revision = new CRevision();
                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                //Revision = manejador.Eliminar_Revision(nombre, apellido, revision);
                return PartialView(Revision);
           

           
            
            

        }
        

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_Revision(string nombre, string apellido, int reserva) //crear reserva restaurant
        {

            CRevision Revision = new CRevision();
            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
           // Revision = manejador.Crear_Revision(nombre, apellido, reserva);
            return PartialView(Revision);

        }

      
    

       

    }
}

