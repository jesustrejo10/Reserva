using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_vuelo;

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

            //llenado dropdownlist de las ciudades origen en la vista crear
            var listaCiudadesO = dlciudadesOrigen();
            {
                model._ciudadesOrigen = listaCiudadesO.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
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
    }
}