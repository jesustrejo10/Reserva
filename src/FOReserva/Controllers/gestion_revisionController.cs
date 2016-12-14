
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
        public ActionResult eliminar_revision()
        {
            return PartialView();
        }

        public ActionResult editar_revision()
        {
            return PartialView();
        }

        public ActionResult crear_revision(int revision1)
        {
            Console.WriteLine("LLEGUE A CREAR REVISION");
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

        public ActionResult Eliminar_Revision_AR(string usuario, CRevision revision)
        {

            List<CRevision> lista = new List<CRevision>();


            //ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
            //lista = manejador.ConsultarRevision2(usuario, revision);


            if (lista == null)
            {

                return PartialView(lista);
            }
            else
            {
                ManejadorSQLRevision manejador2 = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 
                lista = manejador2.Eliminar_Revision(usuario, revision);

                return PartialView(lista);
            }
        }

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>/*
        /*public ActionResult Crear_Revision(CReservation_Restaurant reserva, string usuario) //crear reserva restaurant
        {
            List<CRevision> lista;

            /*  List<CRevision> lista1;
              List<CReservation_Restaurant> rest;
              CReservation_Restaurant res;
             C
              

            // no se si estara bien
            //CReservation_Restaurant n = new CReservation_Restaurant();
            if ((reserva != null)) //&& (  res== reserva))
            {
                ManejadorSQLRevision manejador = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 
                lista = manejador.Crear_Revision(reserva, usuario);
                return PartialView(lista);
            }
            else
            {
                CListRevision modelo = new CListRevision();
                return PartialView(modelo);
            }
			return null;

        }
        */
        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_RevisionHotel(CReservation_Restaurant reserva, string usuario, DateTime fecha) //crear reserva hotel
        {
            List<CRevision> lista;
			return null;
            /*  List<CRevision> lista1;
              List<CReservation_Restaurant> rest;
              CReservation_Restaurant res;
             C
              


            // no se si estara bien
            //CReservation_Restaurant n = new CReservation_Restaurant();
            if ((reserva != null)) //&& (  res== reserva))
            {

                ManejadorSQLRevision manejador = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 
                lista = manejador.Crear_RevisionHotel(reserva, usuario, fecha);
                return PartialView(lista);
            }
            else
            {
                CListRevision modelo = new CListRevision();
                return PartialView(modelo);
            }*/
        }

    } 
}



