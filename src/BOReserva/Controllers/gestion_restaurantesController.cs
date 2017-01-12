using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Servicio;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.LogicaReserva;
using BOReserva.Models;
using BOReserva.LogicaReserva.Fabrica;
using BOReserva.Views.gestion_restaurantes.Fabrica;
using BOReserva.Models.Fabrica;

namespace BOReserva.Controllers
{
    public class gestion_restaurantesController : Controller
    {


        private CRestauranteModelo restaurant;

        public CRestauranteModelo Restaurant
        {
            get
            {
                return restaurant;
            }

            set
            {
                restaurant = value;
            }
        }

        // GET: gestion_restaurantes

        /// <summary>
        /// Método para el acceso a la interfaz de visualización de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Ver(int id = 0)
        {
            ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Nombre");
              

            if (id != 0)
            {
                System.Diagnostics.Debug.WriteLine("el id del restaurant "+id);
                Entidad _lugar = FabricaEntidad.inicializarLugar(id, "");//Aqui se envia la clave foranea de lugar para realizar la busqueda
                Comando<List<Entidad>> comando = (Comando<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, _lugar);
                List<Entidad> restaurantes = comando.Ejecutar();
                CRestauranteModelo Restaurant = FabricaEntidad.inicializarRestaurant();
                List<CRestauranteModelo> lista = FabricaEntidad.inicializarListaRestarant();

                foreach (Entidad item in restaurantes)
                {
                    lista.Add((CRestauranteModelo)item);
                    System.Diagnostics.Debug.WriteLine("el Nombre del restaurant " + ((CRestauranteModelo)item).nombre);
                }

                Restaurant.listaRestaurantes = lista;
                System.Diagnostics.Debug.WriteLine("Salida Interna ");
                return PartialView(Restaurant);
            }


            System.Diagnostics.Debug.WriteLine("Salida Externa ");
            return PartialView();
        }

        /// <summary>
        /// Método para el acceso a la interfaz de agregación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Agregar()
        {
         
            return PartialView();
        }



        [HttpGet]
        public JsonResult verRestaurant(int id)
        {
          //  ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Nombre");
            Entidad _lugar = FabricaEntidad.inicializarLugar(id, "");//Aqui se envia la clave foranea de lugar para realizar la busqueda
            Comando<List<Entidad>> comando = (Comando<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, _lugar);
            List<Entidad> restaurantes = comando.Ejecutar();
            this.Restaurant = FabricaEntidad.inicializarRestaurant();
            List<CRestauranteModelo> lista = FabricaEntidad.inicializarListaRestarant();

            foreach (Entidad item in restaurantes)
            {
                lista.Add((CRestauranteModelo)item);
            }

           this.Restaurant.listaRestaurantes = lista;


            return (Json(true, JsonRequestBehavior.AllowGet)); 
        }
        /// <summary>
        /// Método para el acceso a la interfaz de modificación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Modificar(int id)
        {
           
            var modelo = new CRestauranteModelo
            {
                //id = respuesta.Id,
                //idLugar = respuesta.IdFKLugar,
                //nombre = respuesta,
                //direccion = respuesta._direccion,
                //descripcion = respuesta._descripcion,
                //horarioApertura = respuesta._horarioApertura,
                //horarioCierre = respuesta._horarioCierre
            };
            //modelo._listaCiudades = bd.consultarCiudad();
            return PartialView();
        }

        /// <summary>
        /// Método para el acceso a la interfaz de eliminación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Eliminar()
        {
          
    
            return PartialView();
        }

        /// <summary>
        /// Método para el almacenado de restaurantes, tomando como parámetro un modelo de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpPost]
        public JsonResult guardarRestaurante(CRestauranteModelo model)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((model.nombre == null) || (model.direccion == null) 
                || (model.horarioApertura == null) || (model.horarioCierre == null) || (model.idLugar == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
            manejadorSQL sql = new manejadorSQL();
            var salida = new CRestauranteModelo
            {
                nombre = model.nombre,
                direccion = model.direccion,
                descripcion = model.descripcion,
                horarioApertura = model.horarioApertura,
                horarioCierre = model.horarioCierre,
                idLugar = model.idLugar
            };
         
            if (true)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando el restaurante.";
                return Json(error);
            }
        }

        /// <summary>
        /// Método para la modificación de restaurantes, tomando como parámetro un modelo de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>


        [HttpPost]
        public JsonResult modificarRestaurante(CRestauranteModelo model)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((model.id == -1) || (model.nombre == null) || (model.direccion == null)
                || (model.horarioApertura == null) || (model.horarioCierre == null) || (model.idLugar == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
            manejadorSQL sql = new manejadorSQL();
            var salida = new CRestauranteModelo
            {
                id = model.id,
                nombre = model.nombre,
                direccion = model.direccion,
                descripcion = model.descripcion,
                horarioApertura = model.horarioApertura,
                horarioCierre = model.horarioCierre,
                idLugar = model.idLugar
            };
          
            if (true)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error modificando el restaurante.";
                return Json(error);
            }
        }

        /// <summary>
        /// Método para la eliminación de restaurantes, tomando como parámetro un id de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpGet]
        public JsonResult eliminarRestaurante(int id)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((id == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
     
            if (true)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error eliminando el restaurante.";
                return Json(error);
            }

        }

        public List<Lugar> cargarComboBoxLugar()
        {
            Comando<List<Entidad>> comando = (Comando<List<Entidad>>)FabricaComando.comandosVistaRestaurant(FabricaComando.comandoVista.CARGAR_LUGAR);
            List<Entidad> lugares = comando.Ejecutar();
            List<Lugar> lista = FabricaEntidad.inicializarListaLugar() ;
            Lugar lug;
            foreach (Entidad lugar in lugares)
            {
                lug = (Lugar)lugar;
                lista.Add(lug);

            }
            return lista;
           
        }
    }
}