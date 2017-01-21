
using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System.Collections.Generic;
using FOReserva.Models.Restaurantes;
using System.Web.Mvc;
using System;

namespace FOReserva.Controllers
{
    /// <summary>
    /// Gestion Revision Controlador
    /// </summary>

    public class gestion_revisionController : Controller
    {
        /// <summary>
        /// GET: GestionRevision
        /// </summary>
        /// <returns></returns>
        public ActionResult gestion_revision()
        {
            return PartialView();
        }

        public ActionResult lista_revisiones(int revision)
        {
            Console.WriteLine("Lista Rev " + revision);
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            List<CRevision> lista = manejador.BuscarRevisiones(revision);
            return PartialView(lista);
        }

        public ActionResult crear_revision_form(string rev_mensaje, int rev_puntuacion)
        {
           
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            bool resp = manejador.Crear_Revision(rev_mensaje, rev_puntuacion);
            return PartialView();

        }

        public ActionResult consultar_revision()
        {
            return PartialView();
        }
      
        public ActionResult eliminar_revision(int Id) 
        {
            
                ManejadorSQLRevision manejador = new ManejadorSQLRevision();
                manejador.Eliminar_Revision(Id);
                return PartialView();
           

           
        }

        public ActionResult editar_revision()
        {
            return PartialView();
        }

        public ActionResult crear_revision(int revision1)
        {
            
            CRevision rev = new CRevision();
            return PartialView(rev);
        }
    
        /// <summary>
        /// Creacion Modelo Lista Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Consultar_Revision_AR(string usuario)
        {
            // int search_val = Int32.Parse(Request.QueryString["search_val"]);
            // string Usuario = Request.QueryString["Usuario"];
            List<CRevision> lista;
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            lista = manejador.ConsultarRevision(usuario);

            return PartialView(lista);
        }

        public ActionResult Revision_usuario()
        {
            //Console.WriteLine("Lista Rev " + usuario);
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            List<CRevision> lista = manejador.BuscarRevisionesUsuario();
            return PartialView(lista);
        }

      
        
        }

    } 




