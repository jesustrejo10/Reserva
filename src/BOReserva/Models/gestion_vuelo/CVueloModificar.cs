using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_vuelo
{
    public class CVueloModificar
    {
        public int _id { get; set; }
        public String _codigoVuelo { get; set; }
        public String _codigoVueloNuevo { get; set; }
        public String _fechaAterrizaje { get; set; }
        public String _fechaDespegue { get; set; }
        public String _horaAterrizaje { get; set; }
        public String _horaDespegue { get; set; }
        public String _ciudadOrigen { get; set; }
        public String _ciudadOrigenNuevo { get; set; }
        public String _ciudadDestinoNuevo { get; set; }
        // _ciudadesOrigen tendra todos los valores que iran dentro del DropdownList
        public IEnumerable<SelectListItem> _ciudadesOrigen { get; set; }
        public IEnumerable<SelectListItem> _ciudadesDestino { get; set; }
        public String _matriculaAvion { get; set; }
        // me van a pasar un int, pero lo convertiremos a string
        public String _pasajerosAvion { get; set; }
        // me van a pasar un int, pero lo convertiremos a string
        public String _distanciaMaxima { get; set; }
        public String _modeloAvion { get; set; }
        public String _ciudadDestino { get; set; }
        public String _velocidadMaxima { get; set; }
        public String _statusVuelo { get; set; }

        public CVueloModificar() { }
        public CVueloModificar(int id, String codigovuelo, String fechaAterrizaje, String fechaDespegue, String matriculaavion, String modeloavion, String pasajerosavion,
            String velocidadavion, String distanciaavion, String status, String ciudadorigen, String ciudaddestino)
        {
            _id = id;
            _codigoVuelo = codigovuelo;
            _fechaAterrizaje = fechaAterrizaje;
            _fechaDespegue = fechaDespegue;
            _ciudadOrigen = ciudadorigen;
            _ciudadDestino = ciudaddestino;
            _statusVuelo = status;
            _matriculaAvion = matriculaavion;
            _distanciaMaxima = distanciaavion;
            _modeloAvion = modeloavion;
            _pasajerosAvion = pasajerosavion;
            _velocidadMaxima = velocidadavion;
        }



    }
}