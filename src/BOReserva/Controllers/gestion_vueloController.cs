using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Models.gestion_vuelo;
using BOReserva.Servicio;

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
            manejadorSQL sql = new manejadorSQL();


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


     //b   public ActionResult M04_GestionVuelo_Visualizar()
     //b   {
            //var companies = DataRepository.GetCompanies();
            //List<CAutomovil> listavehiculos = new List<CAutomovil>();
      //b      CBasededatos_vehiculo buscarvehiculos = new CBasededatos_vehiculo();
      //b      List<CAutomovil> listavehiculos = buscarvehiculos.MListarvehiculosBD();  //AQUI SE BUSCA TODO LOS VEHICULOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            //CAutomovil test = new CAutomovil("AG234FC", "3", "Mazda", 2006, "Sedan", 1589.5, 5, 7550.0, 250.6, 290.4, DateTime.Parse("11/11/2016"), "Azul", 1, "Automatico", "Venezuela", "Distrito Capital", "Caracas");
            //listavehiculos.Add(test);

       //b     return PartialView(listavehiculos);
       //b }


        //Evento POST de la view de crear vuelo


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarDestinos(string ciudadO)
        {
            CCrear_Vuelo model = new CCrear_Vuelo();
            List<CCrear_Vuelo> resultado = new List<CCrear_Vuelo>();
            manejadorSQL sql = new manejadorSQL();


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

            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            int resultado = sql.idRutaVuelo(model);
            //envio una respuesta dependiendo del resultado del insert
            

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult trabajoVisualizar(CCrear_Vuelo model)
        {
            return (Json(true, JsonRequestBehavior.AllowGet));
        }
    }
}