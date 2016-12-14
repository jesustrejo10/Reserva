<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
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


        public ActionResult M04_GestionVuelo_Visualizar()
        {
            manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
            List<CVuelo> listavuelos = buscarvuelos.MListarvuelosBD(); //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            return PartialView(listavuelos);
        }

        //VISTA-CREAR: dlstatusvuelo() sera el metodo para llenar el DropdownList del status de vuelo
        public string[] dlstatusvuelo()
        {
            string[] _listaEstados = new String[2];
            _listaEstados[0] = "Activo";
            _listaEstados[1] = "Inactivo";
            return _listaEstados;
        }

        //VISTA-CREAR: Abriendo la vista, aqui se cargan todos los valores antes de inicializarla
        public ActionResult M04_GestionVuelo_Crear()
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            //creo lista donde voy a almacener todas las ciudades de tipo origen en rutas aereas
            List<CCrear_Vuelo> resultadoOrigenes = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //hago llamado a metodo que llena la lista desde BD
            resultadoOrigenes = sql.cargarOrigenes();

            //llenado dropdownlist de las ciudades origen en la vista crear
            {
                model._ciudadesOrigen = resultadoOrigenes.Select(x => new SelectListItem
                {
                    Value = x._ciudadOrigen,
                    Text = x._ciudadOrigen
                });
            };

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

            //llamo a metodo que llena la lista con BD
            resultado = sql.buscarAviones(ciudadO, ciudadD);

            //paso la lista al formato de DropDownList
            model._matriculasAvion = resultado.Select(m => new SelectListItem
            {
                Value = m._matriculaAvion,
                Text = m._matriculaAvion
            });

            if (resultado != null)
            {
                return (Json(model._matriculasAvion, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }



        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaModeloA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.modeloAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaPasajerosA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.pasajerosAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaDistanciaA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.distanciaAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaVelocidadA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.velocidadAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarDestinos(string ciudadO)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            List<CCrear_Vuelo> resultado = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD que llenara lista
            resultado = sql.consultarDestinos(ciudadO);

            //paso la lista a formato de DropDownList para la vista
            model._ciudadesDestino = resultado.Select(m => new SelectListItem
                {
                    Value = m._ciudadDestino,
                    Text = m._ciudadDestino
                });

            if (resultado != null)
            {
                return (Json(model._ciudadesDestino, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }


        [HttpPost]
        public JsonResult guardarVuelo(CCrear_Vuelo model)
        {

            string resultadoFechaAterrizaje = "";
            string resultadoFechaDespegue = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //tomo todas la variables que se introducieron en la vista
            String codigoVuelo = model._codigoVuelo;
            String ciudadOrigen = model._ciudadOrigen;
            String ciudadDestino = model._ciudadDestino;
            String fechaDespegue = model._fechaDespegue;
            String horaDespegue = model._horaDespegue;
            String matriculaAvion = model._matriculaAvion;
            String statusAvion = model._statusVuelo;
            String fechaAterrizaje = model._fechaAterrizaje;
            String horaAterrizaje = model._horaAterrizaje;

            //convierto fecha y hora en formato que acepte la BD
            resultadoFechaDespegue = "" + fechaDespegue + " " + horaDespegue;
            //metodo para calcular la fecha y hora de aterrizaje del vuelo, que luego llama a Stored Procedure
            resultadoFechaAterrizaje = sql.fechaVuelo(fechaDespegue, horaDespegue, ciudadOrigen, ciudadDestino, matriculaAvion);

            //elimino caracteres sobrantes para insert correcto
            resultadoFechaAterrizaje = Regex.Replace(resultadoFechaAterrizaje, ":00", "");

            //procedo a insertar en la tabla Vuelo de la BD
            bool resultado = sql.insertarVuelo(codigoVuelo, ciudadOrigen, ciudadDestino, resultadoFechaDespegue, statusAvion, resultadoFechaAterrizaje, matriculaAvion);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD";
                return Json(error);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaFechaA(string fechaDes, string horaDes, string ciudadO, string ciudadD, string matriAvion, int opcion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            string fecha = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //llamo a metodo para calcular fecha de aterrizaje segun datos introducidos en la vista
            resultado = sql.fechaVuelo(fechaDes, horaDes, ciudadO, ciudadD, matriAvion);
            //separo el resultado del metodo para poner enviar a TextBoxes diferentes
            string[] separando = resultado.Split(' ');

            // si opcion es igual a "0" obtengo fecha, si es igual a "1" obtengo hora
            fecha = separando[opcion];

            //elimino caracteres sobrantes para la vista 
            if (opcion == 1)
            {
                //elimino caracteres sobrantes para la vista
                fecha = Regex.Replace(fecha, ":00", "");
            }

            if (resultado != null)
            {
                return (Json(fecha, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }

        public ActionResult M04_GestionVuelo_Modificar(String codigovuelo)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVueloModificar vuelo = buscarvuelo.MModificarBD(codigovuelo); //BUSCA EL VUELO A MOSTRAR
                                                                               
            return PartialView(vuelo);
        }



        public ActionResult M04_GestionVuelo_Mostrar(String codigovuelo)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVuelo vuelo = buscarvuelo.MMostrarvueloBD(codigovuelo); //BUSCA EL VUELO A MOSTRAR
                                                                                
            return PartialView(vuelo);
        }


        
    public ActionResult M04_GestionVuelo_Desactivar(String codigovuelo)
    {
        manejadorSQL_Vuelos desactivarvuelo = new manejadorSQL_Vuelos();
        Boolean vuelo = desactivarvuelo.MDesactivarVuelo(codigovuelo); //DESATIVANDO  EL VUELO 
                                                                       //manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
                                                                       //List<CVuelo> listavuelos = buscarvuelos.MListarvuelosBD(); //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
                                                                       //return PartialView(listavuelos);
            return null;
    }

}


=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
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


        public ActionResult M04_GestionVuelo_Visualizar()
        {
            manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
            List<CVuelo> listavuelos = buscarvuelos.MListarvuelosBD(); //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            return PartialView(listavuelos);
        }

        //VISTA-CREAR: dlstatusvuelo() sera el metodo para llenar el DropdownList del status de vuelo
        public string[] dlstatusvuelo()
        {
            string[] _listaEstados = new String[2];
            _listaEstados[0] = "Activo";
            _listaEstados[1] = "Inactivo";
            return _listaEstados;
        }

        //VISTA-CREAR: Abriendo la vista, aqui se cargan todos los valores antes de inicializarla
        public ActionResult M04_GestionVuelo_Crear()
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            //creo lista donde voy a almacener todas las ciudades de tipo origen en rutas aereas
            List<CCrear_Vuelo> resultadoOrigenes = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //hago llamado a metodo que llena la lista desde BD
            resultadoOrigenes = sql.cargarOrigenes();

            //llenado dropdownlist de las ciudades origen en la vista crear
            {
                model._ciudadesOrigen = resultadoOrigenes.Select(x => new SelectListItem
                {
                    Value = x._ciudadOrigen,
                    Text = x._ciudadOrigen
                });
            };

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

            //llamo a metodo que llena la lista con BD
            resultado = sql.buscarAviones(ciudadO, ciudadD);

            //paso la lista al formato de DropDownList
            model._matriculasAvion = resultado.Select(m => new SelectListItem
            {
                Value = m._matriculaAvion,
                Text = m._matriculaAvion
            });

            if (resultado != null)
            {
                return (Json(model._matriculasAvion, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }



        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaModeloA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.modeloAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaPasajerosA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.pasajerosAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaDistanciaA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.distanciaAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaVelocidadA(string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD
            resultado = sql.velocidadAvion(matriAvion);

            if (resultado != null)
            {
                return (Json(resultado, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarDestinos(string ciudadO)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            List<CCrear_Vuelo> resultado = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //metodo para BD que llenara lista
            resultado = sql.consultarDestinos(ciudadO);

            //paso la lista a formato de DropDownList para la vista
            model._ciudadesDestino = resultado.Select(m => new SelectListItem
                {
                    Value = m._ciudadDestino,
                    Text = m._ciudadDestino
                });

            if (resultado != null)
            {
                return (Json(model._ciudadesDestino, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }


        [HttpPost]
        public JsonResult guardarVuelo(CCrear_Vuelo model)
        {

            string resultadoFechaAterrizaje = "";
            string resultadoFechaDespegue = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //tomo todas la variables que se introducieron en la vista
            String codigoVuelo = model._codigoVuelo;
            String ciudadOrigen = model._ciudadOrigen;
            String ciudadDestino = model._ciudadDestino;
            String fechaDespegue = model._fechaDespegue;
            String horaDespegue = model._horaDespegue;
            String matriculaAvion = model._matriculaAvion;
            String statusAvion = model._statusVuelo;
            String fechaAterrizaje = model._fechaAterrizaje;
            String horaAterrizaje = model._horaAterrizaje;

            //convierto fecha y hora en formato que acepte la BD
            resultadoFechaDespegue = "" + fechaDespegue + " " + horaDespegue;
            //metodo para calcular la fecha y hora de aterrizaje del vuelo, que luego llama a Stored Procedure
            resultadoFechaAterrizaje = sql.fechaVuelo(fechaDespegue, horaDespegue, ciudadOrigen, ciudadDestino, matriculaAvion);

            //elimino caracteres sobrantes para insert correcto
            resultadoFechaAterrizaje = Regex.Replace(resultadoFechaAterrizaje, ":00", "");

            //procedo a insertar en la tabla Vuelo de la BD
            bool resultado = sql.insertarVuelo(codigoVuelo, ciudadOrigen, ciudadDestino, resultadoFechaDespegue, statusAvion, resultadoFechaAterrizaje, matriculaAvion);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD";
                return Json(error);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaFechaA(string fechaDes, string horaDes, string ciudadO, string ciudadD, string matriAvion, int opcion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            string fecha = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();

            //llamo a metodo para calcular fecha de aterrizaje segun datos introducidos en la vista
            resultado = sql.fechaVuelo(fechaDes, horaDes, ciudadO, ciudadD, matriAvion);
            //separo el resultado del metodo para poner enviar a TextBoxes diferentes
            string[] separando = resultado.Split(' ');

            // si opcion es igual a "0" obtengo fecha, si es igual a "1" obtengo hora
            fecha = separando[opcion];

            //elimino caracteres sobrantes para la vista 
            if (opcion == 1)
            {
                //elimino caracteres sobrantes para la vista
                fecha = Regex.Replace(fecha, ":00", "");
            }

            if (resultado != null)
            {
                return (Json(fecha, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }

        public ActionResult M04_GestionVuelo_Modificar(String codigovuelo)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVueloModificar vuelo = buscarvuelo.MModificarBD(codigovuelo); //BUSCA EL VUELO A MOSTRAR
                                                                               
            return PartialView(vuelo);
        }



        public ActionResult M04_GestionVuelo_Mostrar(String codigovuelo)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVuelo vuelo = buscarvuelo.MMostrarvueloBD(codigovuelo); //BUSCA EL VUELO A MOSTRAR
                                                                                
            return PartialView(vuelo);
        }


        
    public ActionResult M04_GestionVuelo_Desactivar(String codigovuelo)
    {
        manejadorSQL_Vuelos desactivarvuelo = new manejadorSQL_Vuelos();
        Boolean vuelo = desactivarvuelo.MDesactivarVuelo(codigovuelo); //DESATIVANDO  EL VUELO 
                                                                       //manejadorSQL_Vuelos buscarvuelos = new manejadorSQL_Vuelos();
                                                                       //List<CVuelo> listavuelos = buscarvuelos.MListarvuelosBD(); //AQUI SE BUSCA TODO LOS VUELOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
                                                                       //return PartialView(listavuelos);
            return null;
    }

}


>>>>>>> Develop
}