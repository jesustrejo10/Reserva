﻿using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Restaurantes;

namespace FOReserva.Controllers
{

<<<<<<< HEAD
    /// <summary>
    /// Gestion Revision Controlador
    /// </summary>
=======

>>>>>>> refs/remotes/origin/Develop
    public class gestion_revisionController : Controller
    {
        /// <summary>
        /// Creacion Modelo Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Gestion_Revision()
        {
            CRevision modelo = new CRevision();
            return PartialView(modelo);
        }

        /// <summary>
        /// Creacion Modelo Lista Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Gestion_ListRevision()
        {
            CListRevision modelo = new CListRevision();
            return PartialView(modelo);
        }

        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Eliminar_Revision()
        {
            CRevision modelo = new CRevision();
            return PartialView(modelo);
        }

        /// <summary>
        /// Creacion Modelo Consultar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Consultar_Revision()
        {
            CRevision modelo = new CRevision();
            return PartialView(modelo);
        }

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_revision()
        {
            CRevision modelo = new CRevision();
            return PartialView(modelo);
        }

        /// <summary>
        /// Creacion Modelo Editar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Editar_revision()
        {
            CRevision modelo = new CRevision();
            return PartialView(modelo);
        }

        /// <summary>
        /// Creacion Modelo Lista Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Consultar_Revision(string usuario)
        {
            // int search_val = Int32.Parse(Request.QueryString["search_val"]);
            // string Usuario = Request.QueryString["Usuario"];

<<<<<<< HEAD
            List<CRevision> lista;
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();

=======
            //probando
        }




        public ActionResult Consultar_Revision(string usuario)
        {
            // int search_val = Int32.Parse(Request.QueryString["search_val"]);
            // string Usuario = Request.QueryString["Usuario"];


            List<CRevision> lista;


            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
>>>>>>> refs/remotes/origin/Develop
            lista = manejador.ConsultarRevision(usuario);

            return PartialView(lista);
        }

<<<<<<< HEAD
        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Eliminar_Revision(string usuario, CRevision revision)
        {
            List<CRevision> lista;
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 

            lista = manejador.ConsultarRevision2(usuario, revision);

            if (lista == null)
            {
                return PartialView(lista);  // no deberia dejar eliminar
=======


        public ActionResult Eliminar_Revision(string usuario, CRevision revision)
        {

            List<CRevision> lista;


            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
            lista = manejador.ConsultarRevision2(usuario, revision);


            if (lista == null)
            {

                return PartialView(lista);

>>>>>>> refs/remotes/origin/Develop
            }
            else
            {
                ManejadorSQLRevision manejador2 = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 

<<<<<<< HEAD
                lista = manejador2.Eliminar_Revision(usuario, revision);

                return PartialView(lista);
            }
        }

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_Revision(CReservation_Restaurant reserva, string usuario) //crear reserva restaurant
        {
            List<CRevision> lista;

            /*  List<CRevision> lista1;
              List<CReservation_Restaurant> rest;
              CReservation_Restaurant res;
             C
              */

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
=======
                ManejadorSQLMuestraRevision manejador2 = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                lista = manejador2.Eliminar_Revision(usuario, revision);

                return PartialView(lista);


            }


>>>>>>> refs/remotes/origin/Develop
        }

        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_RevisionHotel(CReservation_Restaurant reserva, string usuario, DateTime fecha) //crear reserva hotel
        {
            List<CRevision> lista;

            /*  List<CRevision> lista1;
              List<CReservation_Restaurant> rest;
              CReservation_Restaurant res;
             C
              */

<<<<<<< HEAD
=======
        public ActionResult Crear_Revsion(CReservation_Restaurant reserva, string usuario, DateTime fecha)                 //crear reserva restaurant
        {


            List<CRevision> lista;


            /*  List<CRevision> lista1;
              List<CReservation_Restaurant> rest;
              CReservation_Restaurant res;
             C
              */

>>>>>>> refs/remotes/origin/Develop
            // no se si estara bien
            //CReservation_Restaurant n = new CReservation_Restaurant();
            if ((reserva != null)) //&& (  res== reserva))
            {
<<<<<<< HEAD
                ManejadorSQLRevision manejador = new ManejadorSQLRevision();  // crear en Servicios un manejador para listar 
                lista = manejador.Crear_RevisionHotel(reserva, usuario, fecha);
                return PartialView(lista);
            }
            else
            {
                CListRevision modelo = new CListRevision();
                return PartialView(modelo);
            }
        }

    } 
}




=======

                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                lista = manejador.Crear_Revision(reserva, usuario);
                return PartialView(lista);

            }

            else
            {

                CListRevision modelo = new CListRevision();
                return PartialView(modelo);
            }




        }    //  hasta aca crear Rev

    }

}

>>>>>>> refs/remotes/origin/Develop