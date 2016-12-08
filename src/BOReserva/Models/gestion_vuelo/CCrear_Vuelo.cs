using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_vuelo
{
    public class CCrear_Vuelo
    {
        public String _fechaAterrizaje { get; set; }
        public String _fechaDespegue { get; set; }
        public String _horaAterrizaje { get; set; }
        public String _horaDespegue { get; set; }
        public String _codigoVuelo { get; set; }
        public String _ciudadOrigen { get; set; }
        // _ciudadesOrigen tendra todos los valores que iran dentro del DropdownList
        public IEnumerable<SelectListItem> _ciudadesOrigen { get; set; }
        // _matriculasAvion tendra todos los valores que iran dentro del DropdownList
        public IEnumerable<SelectListItem> _matriculasAvion { get; set; }
        public String _matriculaAvion { get; set; }

        // me van a pasar un int, pero lo convertiremos a string
        public String _pasajerosAvion { get; set; }
        // me van a pasar un int, pero lo convertiremos a string
        public String _distanciaMaxima { get; set; }
        public String _modeloAvion { get; set; }
        public String _ciudadDestino { get; set; }
        public String _velocidadMaxima { get; set; }
        // _ciudadesDestino tendra todos los valores que iran dentro del DropdownList
        public IEnumerable<SelectListItem> _ciudadesDestino { get; set; }
        public String _statusVuelo { get; set; }
        // _statusVuelo tendra todos los valores que iran dentro del DropdownList
        public IEnumerable<SelectListItem> _statusesVuelo { get; set; }




    }
}