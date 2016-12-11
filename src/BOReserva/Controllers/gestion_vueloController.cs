using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Models.gestion_vuelo;
using BOReserva.Servicio.Servicio_Vuelos;

namespace BOReserva.Controllers
{
    public class gestion_vueloController : Controller
    {
        //
        // GET: /gestion_vuelo/


        public ActionResult M04_GestionVuelo_Visualizar()
        {
            return PartialView();
        }


        //VISTA-CREAR: dlciudadesOrigen() sera el metodo para llenar el DropdownList de las ciudades de Origen
        public string[] dlciudadesOrigen()
        {
            string[] _listaCiudadesO = new String[4];
            _listaCiudadesO[0] = "Caracas";
            _listaCiudadesO[1] = "Barquisimeto";
            _listaCiudadesO[2] = "Miami";
            _listaCiudadesO[3] = "San Francisco";
            return _listaCiudadesO;
        }

        //VISTA-CREAR: dlstatusvuelo() sera el metodo para llenar el DropdownList del status de vuelo
        public string[] dlstatusvuelo()
        {
            string[] _listaEstados = new String[2];
            _listaEstados[0] = "Activo";
            _listaEstados[1] = "Inactivo";
            return _listaEstados;
        }

        //VISTA-CREAR: dlciudadesDestino() sera el metodo para llenar el DropdownList de las ciudades de destino
        public string[] dlciudadesDestino()
        {
            string[] _listaCiudadesD = new String[5];
            _listaCiudadesD[0] = "Bogota";
            _listaCiudadesD[1] = "Fort Lauderdale";
            _listaCiudadesD[2] = "Maracaibo";
            _listaCiudadesD[3] = "Buenos Aires";
            _listaCiudadesD[4] = "Quito";
            return _listaCiudadesD;
        }

        //VISTA-CREAR: dlmatriculasAvion() sera el metodo para llenar el DropdownList de las ciudades de Origen
        public string[] dlmatriculasAvion()
        {
            string[] _listamatriculasAvion = new String[4];
            _listamatriculasAvion[0] = "YV 2708";
            _listamatriculasAvion[1] = "YV 0210";
            _listamatriculasAvion[2] = "YV 2512";
            _listamatriculasAvion[3] = "YV 3004";
            return _listamatriculasAvion;
        }

        //VISTA-CREAR: Abriendo la vista, aqui se cargan todos los valores antes de inicializarla
        public ActionResult M04_GestionVuelo_Crear()
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            List<CCrear_Vuelo> resultadoOrigenes = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();


            resultadoOrigenes = sql.cargarOrigenes();

            //llenado dropdownlist de las ciudades origen en la vista crear
            {
                model._ciudadesOrigen = resultadoOrigenes.Select(x => new SelectListItem
                {
                    Value = x._ciudadOrigen,
                    Text = x._ciudadOrigen
                });
            };

            //llenado dropdownlist de los estados de vuelo
            var listaEstados = dlstatusvuelo();
            {
                model._statusesVuelo = listaEstados.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
            };

            //llenado dropdownlist de las matriculas de aviones en la vista crear
            var listamatriculas = dlmatriculasAvion();
            {
                model._matriculasAvion = listamatriculas.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
            };

            //llenado dropdownlist de las ciudades destino en la vista crear
            var listaCiudadesD = dlciudadesDestino();
            {
                model._ciudadesDestino = listaCiudadesD.Select(x => new SelectListItem
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
            List<CCrear_Vuelo> resultado = new List<CCrear_Vuelo>();
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();


            resultado = sql.buscarAviones(ciudadO, ciudadD);

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


            resultado = sql.consultarDestinos(ciudadO);

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



            String codigoVuelo = model._codigoVuelo;
            String ciudadOrigen = model._ciudadOrigen;
            String fechaDespegue = model._fechaDespegue;
            String horaDespegue = model._horaDespegue;
            String matriculaAvion = model._matriculaAvion;
            String ciudadDestino = model._ciudadDestino;
            String fechaAterrizaje = model._fechaAterrizaje;
            String horaAterrizaje = model._horaAterrizaje;
            String statusAvion = model._statusVuelo;

            

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult trabajoVisualizar(CCrear_Vuelo model)
        {
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult buscaFechaA(string fechaDes, string horaDes, string ciudadO, string ciudadD, string matriAvion)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            string resultado = "";
            string fecha = "";
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();


            resultado = sql.fechaVuelo(fechaDes, horaDes, ciudadO, ciudadD, matriAvion);

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

    }
}