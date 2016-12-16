using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Itinerario;
using System.Net;
using FOReserva.Servicio;
using System.Data.SqlClient;

namespace FOReserva.Controllers
{
    public class gestion_planificacion_vacacionesController : Controller
    {
        // GET: /gestion_planificacion_vacaciones/

        public ActionResult M17_gestion_itinerario_Perfil()
        {
           
            Cvista_Itinerario model = new Cvista_Itinerario();
            List<String> lista = new List<string>();

            ManejadorSQLItinerario sql = new ManejadorSQLItinerario();

            lista = sql.listarLugares();

            model._lciudad = lista.Select(x => new SelectListItem
            {
                Value = x,
                Text = x
            });

            return PartialView(model);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarFechas(string ciudadO)
        {
            Cvista_Itinerario model = new Cvista_Itinerario();
            List<String> resultado = new List<String>();
            ManejadorSQLItinerario sql = new ManejadorSQLItinerario();
            resultado = sql.consultarFechas(ciudadO);
            model._lfecha = resultado.Select(m => new SelectListItem
            {
                Value = m,
                Text = m
            });

            if (resultado != null)
            {
                return (Json(model._lfecha, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Usted no tiene fechas o destinos asignados";
                return Json(error);
            }
        }

        [HttpPost]
        public JsonResult guardarItinerario(Cvista_Itinerario model)
        {
            //VALIDA QUE NO INSERTE CAMPOS VACIOS
            if ((model._actividad == null) || (model._actividad.Contains("select")) || (model._actividad.Contains("Select")) ||
                (model._actividad.Contains("SELECT")) || (model._actividad.Contains("update")) || (model._actividad.Contains("UPDATE")) ||
                (model._actividad.Contains("Update")) || (model._actividad.Contains("INSERT")) || (model._actividad.Contains("insert")) ||
                (model._actividad.Contains("Insert")) ||  (model._actividad.Contains("Delete")) ||  (model._actividad.Contains("delete")) ||
                 (model._actividad.Contains("DELETE")))
            {
         
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campo vacio o texto invalido.";
                //Retorno el error
                return Json(error);
            }

            //instancio el manejador de sql
            ManejadorSQLItinerario sql = new ManejadorSQLItinerario();
            //realizo el insert
            try
            {
                bool resultado = sql.insertarItinerario(model);
                //envio una respuesta dependiendo del resultado del insert
                if (resultado)
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error inesperado.";
                return Json(error);
            }

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

        [HttpPost]
        public JsonResult eliminarItinerario(Cvista_Itinerario model)
        {
            ManejadorSQLItinerario sql = new ManejadorSQLItinerario();
            Boolean resultado = sql.eliminarItinerario(model);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta   
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos, no posee registros a borrar";
                //Retorno el error  
                return Json(error);
            }
        }

        [HttpPost]
        public JsonResult modificarItinerario(Cvista_Itinerario model)
        {
            ManejadorSQLItinerario sql = new ManejadorSQLItinerario();
            Boolean resultado = sql.modificarItinerario(model);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos, no posee registros a modificar";
                //Retorno el error  
                return Json(error);
            }
        }

        public JsonResult consultarActividad(Cvista_Itinerario model)
        {
            ManejadorSQLItinerario maneja = new ManejadorSQLItinerario();
            String boleto = model._ciudad;
            String dia = model._fecha;
            String resultado = maneja.buscarActividad(boleto, dia);
            return (Json(resultado, JsonRequestBehavior.AllowGet));
        }

     

    }
}
