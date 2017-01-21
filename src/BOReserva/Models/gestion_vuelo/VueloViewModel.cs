using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_vuelo
{
    public abstract class VueloViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public String _fechaAterrizaje { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _fechaDespegue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _horaAterrizaje { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _horaDespegue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _codigoVuelo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int  _idRuta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _ciudadOrigen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> _ciudadesOrigen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> _matriculasAvion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _matriculaAvion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _pasajerosAvion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _distanciaMaxima { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _modeloAvion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _ciudadDestino { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String _velocidadMaxima { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> _ciudadesDestino { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String  _statusVuelo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> _comboStatus { get; set; }

        public int _idCiudadOrigen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int _idAvion { get; set; }
    }
}