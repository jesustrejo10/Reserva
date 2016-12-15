using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BOReserva.Models.gestion_vuelo;
using BOReserva.Servicio.Servicio_Vuelos;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase que emite las respuestas de los eventos AJAX
    /// </summary>
    public class gestion_vueloController : Controller
    {
        //
        // GET: /gestion_vuelo/
        public static String _origen;
        public static String _destino;
        public static String _avion;


        public ActionResult M04_GestionVuelo_Visualizar()
        {
            manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
            List<CVuelo> listavuelos = new List<CVuelo>();
            try
            {
                //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
                listavuelos = buscarvuelos.MListarvuelosBD(); 
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando la pagina visualizar desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando la pagina visualizar, contacte con el administrador.";
                return Json(error);
            }
            return PartialView(listavuelos);
        }

        //VISTA-CREAR: dlstatusvuelo() sera el metodo para llenar el DropdownList del status de vuelo
        public string[] dlstatusvuelo()
        {
            string[] _listaEstados = new String[2];
            _listaEstados[0] = "activo";
            _listaEstados[1] = "inactivo";
            return _listaEstados;
        }

        //VISTA-CREAR: Abriendo la vista, aqui se cargan todos los valores antes de inicializarla
        public ActionResult M04_GestionVuelo_Crear()
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            //creo lista donde voy a almacener todas las ciudades de tipo origen en rutas aereas
            List<CCrear_Vuelo> resultadoOrigenes = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();


            try
            {
                //hago llamado a metodo que llena la lista desde BD
                  resultadoOrigenes = sql.cargarOrigenes();
                //llenado dropdownlist de las ciudades origen en la vista crear
                  if (resultadoOrigenes != null)
                  {
                      model._ciudadesOrigen = resultadoOrigenes.Select(x => new SelectListItem
                      {
                          Value = x._ciudadOrigen,
                          Text = x._ciudadOrigen
                      });
                  }

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para la pagina agregar.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido ingresando a la pagina agregar, contacte con el administrador.";
                return Json(error);
            }


            //paso la lista al formato de DropDownList
            var listaEstados = dlstatusvuelo();
            {
                model._statusesVuelo = listaEstados.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
            };

            return PartialView(model);
        }

        //Evento POST de la view de crear vuelo

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult validarAviones(string ciudadO, string ciudadD)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            //creo la lista que lleno con las matriculas de avion que cubren la ruta especificada
            List<CCrear_Vuelo> resultado = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            try
            {
                //llamo a metodo que llena la lista con BD
                resultado = sql.buscarAviones(ciudadO, ciudadD);

                if (resultado!= null)
                {
                    //paso la lista al formato de DropDownList
                    model._matriculasAvion = resultado.Select(m => new SelectListItem
                    {
                        Value = m._matriculaAvion,
                        Text = m._matriculaAvion
                    });
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }

                return (Json(model._matriculasAvion, JsonRequestBehavior.AllowGet));
        }


        [HttpPost]
        public JsonResult buscaModeloA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            try
            {
                //metodo para BD
                resultado = sql.modeloAvion(matriAvion);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando el modelo del avion.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando el modelo del avion, contacte con el administrador.";
                return Json(error);
            }
                
            return (Json(resultado, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult buscaPasajerosA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            try
            {
                //metodo para BD
                resultado = sql.pasajerosAvion(matriAvion);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando la cantidad de pasajeros.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando la cantidad de pasajeros, contacte con el administrador.";
                return Json(error);
            }

            return (Json(resultado, JsonRequestBehavior.AllowGet)); 

        }



        [HttpPost]
        public JsonResult buscaDistanciaA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            
            try
            {
                //metodo para BD
                resultado = sql.distanciaAvion(matriAvion);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando la distancia maxima del avion.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando la distancia maxima del avion, contacte con el administrador.";
                return Json(error);
            }

            return (Json(resultado, JsonRequestBehavior.AllowGet)); 
        }


        [HttpPost]
        public JsonResult buscaVelocidadA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            

            try
            {
                //metodo para BD
                resultado = sql.velocidadAvion(matriAvion);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando la velocidad del avion.";
                return Json(error,JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando la velocidad del avion, contacte con el administrador.";
                return Json(error, JsonRequestBehavior.DenyGet);
            }

            return (Json(resultado, JsonRequestBehavior.AllowGet)); 
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarDestinos(string ciudadO)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            List<CCrear_Vuelo> resultado = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            try
            {
                //metodo para BD que llenara lista
                resultado = sql.consultarDestinos(ciudadO);
                    //paso la lista a formato de DropDownList para la vista
                if (resultado != null)
                {
                    model._ciudadesDestino = resultado.Select(m => new SelectListItem
                    {
                        Value = m._ciudadDestino,
                        Text = m._ciudadDestino
                    });
                }
                
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando los destinos desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando los destinos, contacte con el administrador.";
                return Json(error);
            }

            return (Json(model._ciudadesDestino, JsonRequestBehavior.AllowGet));
        }


        [HttpPost]
        public JsonResult guardarVuelo(CCrear_Vuelo model)
        {
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();
            if ((model._matriculaAvion == null) || (model._codigoVuelo == null) || (model._ciudadOrigen == null)
                || (model._ciudadDestino == null) || (model._statusVuelo == null) || (model._fechaDespegue == null) || (model._horaDespegue == null))
            {
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campos obligatorios vacios";
                //Retorno el error
                return Json(error);
            }

            try // intento consultar en BD si el Codigo de vuelo ya fue previamente registrado
            {
                int repetido = sql.codVueloUnico(model._codigoVuelo);// llamo a BD
                if (repetido == 1)// vale 1 si ya fue registrado
                {
                    //Creo el codigo de error de respuesta
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "El codigo de vuelo ya esta registrado";
                    //Retorno el error
                    return Json(error);
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error verificando el codigo de vuelo en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido verificando el codigo de vuelo, contacte con el administrador.";
                return Json(error);
            }
         



        //    if ((model._fechaAterrizaje == null) || (model._horaAterrizaje == null))
        //    {
        //        //Creo el codigo de error de respuesta
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        //Agrego mi error
        //        String error = "Error en el calculo de la fecha de aterrizaje. Por favor intente nuevamente y complete los campos obligatorios";
        //        //Retorno el error
        //        return Json(error);
        //    }


            string resultadoFechaAterrizaje = "";
            string resultadoFechaDespegue = "";

            //tomo todas la variables que se introducieron en la vista
            String codigoVuelo = model._codigoVuelo;
            String ciudadOrigen = model._ciudadOrigen;
            String ciudadDestino = model._ciudadDestino;
            String fechaDespegue = model._fechaDespegue;
            String horaDespegue = model._horaDespegue;
            String matriculaAvion = model._matriculaAvion;
            String statusAvion = model._statusVuelo;


            //convierto fecha y hora en formato que acepte la BD
            resultadoFechaDespegue = "" + fechaDespegue + " " + horaDespegue;

            try
            {
                //metodo para calcular la fecha y hora de aterrizaje del vuelo, que luego llama a Stored Procedure
                resultadoFechaAterrizaje = sql.fechaVuelo(fechaDespegue, horaDespegue, ciudadOrigen, ciudadDestino, matriculaAvion);
                //procedo a insertar en la tabla Vuelo de la BD
                bool resultado = sql.insertarVuelo(codigoVuelo, ciudadOrigen, ciudadDestino, resultadoFechaDespegue, statusAvion, resultadoFechaAterrizaje, matriculaAvion);
                //envio una respuesta dependiendo del resultado del insert
                if (resultadoFechaAterrizaje != null)
                {
                    //elimino caracteres sobrantes para insert correcto
                    resultadoFechaAterrizaje = Regex.Replace(resultadoFechaAterrizaje, ":00", "");
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando el vuelo en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido insertando el vuelo, contacte con el administrador.";
                return Json(error);
            }


            return (Json(true, JsonRequestBehavior.AllowGet));
            
        }


        [HttpPost]
        public JsonResult buscaFechaA(string fechaDes, string horaDes, string ciudadO, string ciudadD, string matriAvion, int opcion)
        {

            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            string fecha = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            if ((fechaDes == null) || (horaDes == null))
            {
                //Agrego mi error
                String error = "Error en el calculo de la fecha de aterrizaje. Por favor intente nuevamente y complete los campos obligatorios";
                //Retorno el error
                return Json(error);
            }

            try
            {
                //llamo a metodo para calcular fecha de aterrizaje segun datos introducidos en la vista
                resultado = sql.fechaVuelo(fechaDes, horaDes, ciudadO, ciudadD, matriAvion);
                //separo el resultado del metodo para poner enviar a TextBoxes diferentes
                if (resultado != null)
                {
                    string[] separando = resultado.Split(' ');
                    // si opcion es igual a "0" obtengo fecha, si es igual a "1" obtengo hora
                    fecha = separando[opcion];
                    //elimino caracteres sobrantes para la vista 
                    if (opcion == 1)
                    {
                        //elimino caracteres sobrantes para la vista
                        fecha = Regex.Replace(fecha, ":00", "");
                    }
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error calculando la fecha de aterrizaje en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido calculando la fecha de aterrizaje, contacte con el administrador.";
                return Json(error);
            }
            return (Json(fecha, JsonRequestBehavior.AllowGet));

        }

        public ActionResult M04_GestionVuelo_Modificar(int id)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVueloModificar vuelo = new CVueloModificar();
            try
            {
                vuelo = buscarvuelo.MModificarBD(id); //BUSCA EL VUELO A MOSTRAR
                
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando la vista de modificar desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando la vista modificar, contacte con el administrador.";
                return Json(error);
            }
                                                                   
            return PartialView(vuelo);
        }



        public ActionResult M04_GestionVuelo_Mostrar(int id)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVuelo vuelo = new CVuelo();
            try
            {
               vuelo = buscarvuelo.MMostrarvueloBD(id); //BUSCA EL VUELO A MOSTRAR
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando el vualo a mostrar desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando el vuelo a mostrar, contacte con el administrador.";
                return Json(error);
            }
                                                                  
            return PartialView(vuelo);
        }


        
    public ActionResult M04_GestionVuelo_Desactivar(int id)
    {
        manejadorSQL_Vuelos desactivarvuelo = new manejadorSQL_Vuelos();
        try
        {
            Boolean vuelo = desactivarvuelo.MDesactivarVuelo(id);
            //DESATIVANDO  EL VUELO 
            //manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
            //List<CVuelo> listavuelos = buscarvuelos.MListarvuelosBD(); 
            //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            //return PartialView(listavuelos);
        }
        catch (SqlException e)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            String error = "Error desactivando el vuelo en la base de datos.";
            return Json(error);
        }
        catch (Exception e)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            String error = "Error desconocido desactivando el vuelo, contacte con el administrador.";
            return Json(error);
        }
        
            return null;
    }
    public ActionResult M04_GestionVuelo_Activar(int id)
        {
            manejadorSQL_Vuelos activarvuelo = new manejadorSQL_Vuelos();
            try
            {
                Boolean vuelo = activarvuelo.MActivarVuelo(id);
                //DESATIVANDO  EL VUELO 
                //manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
                //List<CVuelo> listavuelos = buscarvuelos.MListarvuelosBD(); 
                //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
                //return PartialView(listavuelos);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error activando el vuelo en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido activando el vuelo, contacte con el administrador.";
                return Json(error);
            }

            return null;
        }

        public static List<SelectListItem> ciudadesorigen( string CiudadO)
        {
           manejadorSQL_Vuelos ciudadorigen = new manejadorSQL_Vuelos();
            List<SelectListItem> _ciudadorigenes = new List<SelectListItem>();
            String[] origenes = ciudadorigen.MListarciudadesOrigenBD();
            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _ciudadorigenes.Add(new SelectListItem
                    {
                        Text = origenes[i].ToString(),
                        Value = origenes[i].ToString()

                    });
                    if (origenes[i].Equals(CiudadO)) {
                        _origen = origenes[i];
                    }
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _ciudadorigenes;
        }




        public static List<SelectListItem> ciudadesdestino(String COrigen,String CDestino)
        {
            manejadorSQL_Vuelos ciudaddestino = new manejadorSQL_Vuelos();
            List<SelectListItem> _ciudaddestinos = new List<SelectListItem>();
            String[] destinos = ciudaddestino.MListarciudadesDestinoBD(COrigen);
            int i = 0;
           _destino = destinos[0];
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _ciudaddestinos.Add(new SelectListItem
                    {
                        Text = destinos[i].ToString(),
                        Value = destinos[i].ToString()
                    });
                    if (destinos[i].Equals(CDestino))
                    {
                        _destino = destinos[i];
                    }
                        i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _ciudaddestinos;
        }



        public JsonResult cargarDestinosModificar(string ciudadOMod)
        {
            CVueloModificar model = new CVueloModificar();
            List<CVueloModificar> resultado = new List<CVueloModificar>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            try
            {
                //metodo para BD que llenara lista
                resultado = sql.consultarDestinosModificar(ciudadOMod);
                //paso la lista a formato de DropDownList para la vista
                if (resultado != null)
                {
                    model._ciudadesDestino = resultado.Select(m => new SelectListItem
                    {
                        Value = m._ciudadDestino,
                        Text = m._ciudadDestino
                    });
                }

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para cargar los detinos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando los destinos, contacte con el administrador.";
                return Json(error);
            }

            return (Json(model._ciudadesDestino, JsonRequestBehavior.AllowGet));
        }


        [HttpPost]
        public ActionResult revisarCodVuelo(String codVuelo)
        {
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();
            int existe = 0;
            try
            {
               existe = sql.codVueloUnico(codVuelo);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para verificar el codigo.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido verificando codigo, contacte con el administrador.";
                return Json(error);
            }
            return Json(existe);
        } 

        public static List<SelectListItem> avionesvalidados(String COrigen, String CDestino, String Avion)
        {
            manejadorSQL_Vuelos avionvalidado = new manejadorSQL_Vuelos();
            List<SelectListItem> _avionesvalidados = new List<SelectListItem>();
            String[] aviones = avionvalidado.MListaravionesValidadosBD(COrigen, CDestino);
            int i = 0;
            _avion = aviones[0];
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _avionesvalidados.Add(new SelectListItem
                    {
                        Text = aviones[i].ToString(),
                        Value = aviones[i].ToString()
                    });
                    if (aviones[i].Equals(Avion))
                    {
                        _avion = aviones[i];
                    }
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _avionesvalidados;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult validarAvionesModificar(string ciudadO, string ciudadD)
        {
            if (ciudadO.Equals("")) {

                ciudadO = _origen;

            }
            CVueloModificar model = new CVueloModificar();
            //creo la lista que lleno con las matriculas de avion que cubren la ruta especificada
            List<CVueloModificar> resultado = new List<CVueloModificar>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            try
            {
                //llamo a metodo que llena la lista con BD
                resultado = sql.buscarAvionesModificar(ciudadO, ciudadD);

                if (resultado != null)
                {
                    //paso la lista al formato de DropDownList
                    model._matriculaAviones = resultado.Select(m => new SelectListItem
                    {
                        Value = m._matriculaAvion,
                        Text = m._matriculaAvion
                    });
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }

            return (Json(model._matriculaAviones, JsonRequestBehavior.AllowGet));
        }
    }
}
