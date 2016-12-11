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
        /// Creacion Modelo Consultar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>

        public ActionResult Consultar_Revision_Usuario(string nombre, string apellido)
        {

            List<CRevision> lista;
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            lista = manejador.Consultar_Revision(nombre, apellido);

            return PartialView(lista);
        }

        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public bool Eliminar_Revision(string nombre, string apellido, int revision)
        {

           
                bool resultado;
                ManejadorSQLRevision manejador = new ManejadorSQLRevision();
                resultado = manejador.Eliminar_Revision(nombre, apellido, revision);
                return resultado;
           
         
        }

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public bool Crear_Revision(string nombre, string apellido)
        {

            bool Revision;
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            Revision = manejador.Crear_Revision(nombre, apellido);
            return true;

        }

        /// <summary>
        /// Creacion Modelo Mostrar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Mostrar_Revision(string nombre, string apellido, int tipo)
        {

            if (tipo == 1)
            {
                List<CRevision> lista;
                ManejadorSQLRevision manejador = new ManejadorSQLRevision();
                lista = manejador.Mostrar_Revision_Restaurant(nombre, apellido, tipo);
                return PartialView(lista);
            }
            else
            {

                List<CRevision> lista;
                ManejadorSQLRevision manejador = new ManejadorSQLRevision();
                lista = manejador.Mostrar_Revision_Hotel(nombre, apellido, tipo);
                return PartialView(lista);


            }
        }

        /// <summary>
        /// Creacion Modelo Editar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public bool Editar_Revision(string nombre, string apellido, int revision)
        {

            bool resultado;
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            resultado = manejador.Editar_Revision(nombre, apellido, revision);
            return true;


        }



    }
}


