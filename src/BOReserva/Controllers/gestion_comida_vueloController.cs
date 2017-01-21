using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_comida_vuelo;
using System.Net;
using BOReserva.Servicio;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

namespace BOReserva.Controllers
{
    public class gestion_comida_vueloController : Controller
    {
        public ActionResult M06_AgregarComida()
        {
            CAgregarComida model = new CAgregarComida();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult guardarPlato(CAgregarComida model)
        {
            if ((model._nombrePlato == null) || (model._tipoPlato == null) || (model._estatusPlato == null) || (model._descripcionPlato == null))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error, campo obligatorio vacio";
                return Json(error);
            }

            Entidad _comida = FabricaEntidad.instanciarComida(model._nombrePlato, model._tipoPlato, model._estatusPlato, model._descripcionPlato);
            Command<bool> comando = (Command<bool>)FabricaComando.gestionComida(FabricaComando.comandosComida.CREAR_COMIDA, _comida);

            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando comida.";
                return Json(error);
            }
        }

        public ActionResult M06_AgregarPorVuelo()
        {
            manejadorSQL sql = new manejadorSQL();
            //manejadorSQL sqlPasajero = new manejadorSQL();
            List<CVuelo> vuelos = new List<CVuelo>();
            vuelos = sql.listarVuelosEnBD();
            return PartialView(vuelos);
        }

        public ActionResult M06_VisualizarComidas()
        {
            List<Entidad> listaComidas = null;

            Command<List<Entidad>> comando = (Command<List<Entidad>>) FabricaComando.gestionComida(FabricaComando.comandosComida.CONSULTAR_COMIDAS, null);

            listaComidas = comando.ejecutar();

            if (listaComidas != null)
            {
                return PartialView(listaComidas);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error consultando comidas.";
                return Json(error);
            }
        }

        public ActionResult M06_VisualizarVuelosComidas()
        {
            List<Entidad> listaComidasVuelos = null;

            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.gestionComida(FabricaComando.comandosComida.CONSULTAR_COMIDAS_VUELOS, null);

            listaComidasVuelos = comando.ejecutar();

            if (listaComidasVuelos != null)
            {
                return PartialView(listaComidasVuelos);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error consultando vuelos y comidas.";
                return Json(error);
            }

            return PartialView(listaComidasVuelos);
            //return PartialView();
        }

        /// <summary>
        /// Metodo para que el lato este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema </returns>
        [HttpPost]
        public JsonResult habilitarPlato(int id)
        {
            Entidad _comida = FabricaEntidad.instanciarComida(id);
            Command<bool> comando = (Command<bool>)FabricaComando.gestionComida(FabricaComando.comandosComida.HABILITAR_COMIDA, _comida);
            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos";
                //Retorno el error  
                return Json(error);
            }
        }

        /// <summary>
        /// Metodo para que el lato NO este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema</returns>
        [HttpPost]
        public JsonResult deshabilitarPlato(int id)
        {
            Entidad _comida = FabricaEntidad.instanciarComida(id);
            Command<bool> comando = (Command<bool>)FabricaComando.gestionComida(FabricaComando.comandosComida.DESHABILITAR_COMIDA, _comida);

            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos";
                //Retorno el error  
                return Json(error);
            }
        }

        public ActionResult M06_EditarPlato(int id)
        {
            Entidad _comida = FabricaEntidad.instanciarComida(id);
            Command<Entidad> comando = (Command<Entidad>)FabricaComando.gestionComida(FabricaComando.comandosComida.RELLENAR_COMIDA, _comida);

            Entidad comida = comando.ejecutar();
            return PartialView(comida);
        }

        public JsonResult editarPlatoComida(int id, string nombre, string tipo, int estatus, string descripcion) {

            Entidad _comida = FabricaEntidad.instanciarComida(id, nombre, tipo, estatus, descripcion);
            Command<bool> comando = (Command<bool>)FabricaComando.gestionComida(FabricaComando.comandosComida.EDITAR_COMIDA, _comida);
            bool resultado = comando.ejecutar();

            return Json(resultado); 
        }
    }
       
	}

