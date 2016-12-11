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
        public ActionResult Consultar_Revision(string nombre , string apellido)
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
           
            if (revision != null)
            {


                List<CRevision> lista;
                ManejadorSQLMuestraRevision manejador2 = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                lista = manejador2.Eliminar_Revision(nombre, apellido, revision);
                return PartialView(lista);
            }

            else
            {
                List<CRevision> lista;
                ManejadorSQLMuestraRevision manejador2 = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                lista = manejador2.Eliminar_Revision(nombre, apellido, revision);
                return PartialView(lista);

            }

        }
        

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_RevisionRestaurant(int reserva, string nombre, string apellido) //crear reserva restaurant
        {
            List<CRevision> lista;

             // List<CRevision> lista1;
             // List<CReservation_Restaurant> rest;
             // CReservation_Restaurant res;
             
              

            // no se si estara bien
            //CReservation_Restaurant n = new CReservation_Restaurant();
            if ((reserva != null)) //&& (  res== reserva))
            {
                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                lista = manejador.Crear_RevisionRestaurant(reserva, nombre, apellido);
                return PartialView(lista);
            }
            else
            {
                CListRevision modelo = new CListRevision();
                return PartialView(modelo);
            }

            ManejadorSQLMuestraRevision manejador2 = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
            //lista = manejador2.Eliminar_Revision(usuario, revision);*/
            return null;
        }

      
    

       

    }
}

