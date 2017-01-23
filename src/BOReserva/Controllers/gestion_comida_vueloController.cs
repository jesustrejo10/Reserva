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
    /// <summary>
    /// Clase que emite las respuestas de los eventos AJAX
    /// /// Clase Controladora del modulo 6, Gestion de Comidas
    /// </summary>
    public class gestion_comida_vueloController : Controller
    {
        /// <summary>
        /// Metodo para devolver la vista de agregar comida
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene la vista </returns>
        public ActionResult M06_AgregarComida()
        {
            CAgregarComida model = new CAgregarComida();
            return PartialView(model);
        }


        /// <summary>
        /// Metodo para guardar un plato, haciendo el insert en la base de datos 
        /// </summary>
        /// <returns>Retorna un JsonResult que contiene los elementos de la vista </returns>
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


        /// <summary>
        /// Metodo para asociar una comida a un vuelo, haciendo el insert en la base de datos 
        /// </summary>
        /// <returns>Retorna un JsonResult que contiene los elementos de la vista </returns>
        [HttpPost]
        public JsonResult guardarPlatoVuelo(CComida model)
        {
            int id = model._id;
            string idPlato = model._nombrePlato;
            int cantidadPlatos = model._cantidad;
            Entidad _comida = FabricaEntidad.instanciarComidaVuelo(id, idPlato, cantidadPlatos);
            Command<bool> comando = (Command<bool>)FabricaComando.gestionComida(FabricaComando.comandosComida.CREAR_COMIDA_VUELO, _comida);

            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando comida al vuelo.";
                return Json(error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Metodo que lee los vuelos de la base de datos para mostrarlos en agregar comida por vuelo
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M06_AgregarPorVuelo()
        {
            List<Entidad> listaVuelos = null;

            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.gestionComida(FabricaComando.comandosComida.CONSULTAR_VUELOS, null);

            listaVuelos = comando.ejecutar();

            if (listaVuelos != null)
            {
                ViewBag.listaVuelos = listaVuelos;
                return PartialView();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error consultando Vuelos.";
                return Json(error);
            } 
        }


        /// <summary>
        /// Metodo que retorna la vista para asociar comidas a un vuelo
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M06_AgregarComidaVuelo(int id)
        {
            List<Entidad> listaComidas = null;

            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.gestionComida(FabricaComando.comandosComida.CONSULTAR_COMIDAS, null);

            listaComidas = comando.ejecutar();

            if (listaComidas != null)
            {
                ViewBag.idVuelo = id;
                ViewBag.listaComidas = listaComidas;
                return PartialView();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error consultando comidas.";
                return Json(error);
            }
        }

        /// <summary>
        /// Metodo para visualizar las comidas y bebidas
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
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

        /// <summary>
        /// Metodo para visualizar las comidas asociadas a los vuelos
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
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
        /// Metodo para que el plato este disponible para su uso
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
        /// Metodo para que el plato NO este disponible para su uso
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

        /// <summary>
        /// Metodo que retorna la vista para editar el plato
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M06_EditarPlato(int id)
        {
            Entidad _comida = FabricaEntidad.instanciarComida(id);
            Command<Entidad> comando = (Command<Entidad>)FabricaComando.gestionComida(FabricaComando.comandosComida.RELLENAR_COMIDA, _comida);

            Entidad comida = comando.ejecutar();
            return PartialView(comida);
        }


        /// <summary>
        /// Metodo que edita los datos de un plato
        /// </summary>
        /// <returns>Retorna un JsonResult que contiene los elementos de la vista </returns>
        public JsonResult editarPlatoComida(int id, string nombre, string tipo, int estatus, string descripcion) {

            Entidad _comida = FabricaEntidad.instanciarComida(id, nombre, tipo, estatus, descripcion);
            Command<bool> comando = (Command<bool>)FabricaComando.gestionComida(FabricaComando.comandosComida.EDITAR_COMIDA, _comida);
            bool resultado = comando.ejecutar();

            return Json(resultado); 
        }
    }
       
	}

