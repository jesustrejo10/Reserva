using BOReserva.DataAccess.DataAccessObject.M04;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_vuelo
{
    public class CrearVueloMO 
    {

        /// <summary>
        /// fecha aterrizaje
        /// </summary>
        public String _fechaAterrizaje { get; set; }
        /// <summary>
        /// _fechaDespegue
        /// </summary>
        public String _fechaDespegue { get; set; }
        /// <summary>
        /// _horaAterrizaje
        /// </summary>
        public String _horaAterrizaje { get; set; }
        /// <summary>
        /// _horaDespegue
        /// </summary>
        public String _horaDespegue { get; set; }
        /// <summary>
        /// _codigoVuelo
        /// </summary>
        public String _codigoVuelo { get; set; }
        /// <summary>
        /// _idRuta
        /// </summary>
        public int _idRuta { get; set; }
        /// <summary>
        /// _ciudadOrigen
        /// </summary>
        public String _ciudadOrigen { get; set; }
        /// <summary>
        /// _ciudadesOrigen
        /// </summary>
        public IEnumerable<SelectListItem> _ciudadesOrigen { get; set; }
        /// <summary>
        /// _matriculasAvion
        /// </summary>
        public IEnumerable<SelectListItem> _matriculasAvion { get; set; }
        /// <summary>
        /// _matriculaAvion
        /// </summary>
        public String _matriculaAvion { get; set; }
        /// <summary>
        /// _pasajerosAvion
        /// </summary>
        public String _pasajerosAvion { get; set; }
        /// <summary>
        /// _distanciaMaxima
        /// </summary>
        public String _distanciaMaxima { get; set; }
        /// <summary>
        /// _modeloAvion
        /// </summary>
        public String _modeloAvion { get; set; }
        /// <summary>
        /// _ciudadDestino
        /// </summary>
        public String _ciudadDestino { get; set; }
        /// <summary>
        /// _velocidadMaxima
        /// </summary>
        public String _velocidadMaxima { get; set; }
        /// <summary>
        /// _ciudadesDestino
        /// </summary>
        public IEnumerable<SelectListItem> _ciudadesDestino { get; set; }
        /// <summary>
        /// _statusVuelo
        /// </summary>
        public String _statusVuelo { get; set; }
        /// <summary>
        /// _comboStatus
        /// </summary>
        public IEnumerable<SelectListItem> _comboStatus { get; set; }
        /// <summary>
        /// _idCiudadOrigen
        /// </summary>
        public int _idCiudadOrigen { get; set; }
        /// <summary>
        /// _idAvion
        /// </summary>
        public int _idAvion { get; set; }

        /// <summary>
        /// fechaDespegue
        /// </summary>
        public DateTime fechaDespegue { get; set; }

        /// <summary>
        /// _idVuelo
        /// </summary>
        public int _idVuelo { get; set; }

        /// <summary>
        /// Constructor con ciudadesOrigen y comboVuelo
        /// </summary>
        /// <param name="ciudadesOrigen"> lista de ciudades con rutas areas activas</param>
        /// <param name="combo">Lista de los valors del combo de status del vuelo</param>
        public CrearVueloMO()
        {
        }

        public void setFechaDespegue()
        {
            try
            {

                if (_fechaDespegue != null && _horaDespegue != null)
                    fechaDespegue = DateTime.ParseExact((_fechaDespegue + " " + _horaDespegue), "yyyy-MM-dd HH:mm",
                                              System.Globalization.CultureInfo.InvariantCulture);
                else
                    throw new ReservaExceptionM04(RecursoAvionCO.CodigoErrorFormulario, RecursoAvionCO.MensajeCampoVacio);
            }
            catch (Exception ex)
            {
                throw new ReservaExceptionM04(RecursoAvionCO.CodigoErrorFormulario, RecursoAvionCO.MensajeErrorFomulario, ex);
            }
        }

        public DateTime getFechaAterrizaje()
        {
            try
            {
                if (_fechaAterrizaje != null && _horaAterrizaje != null)
                   return (DateTime.ParseExact((_fechaAterrizaje + " " + _horaAterrizaje), "dd/MM/yyyy HH:mm",
                                           System.Globalization.CultureInfo.InvariantCulture));
                else
                    throw new ReservaExceptionM04(RecursoAvionCO.CodigoErrorFormulario, RecursoAvionCO.MensajeCampoVacio);
            }
            catch (Exception ex)
            {
                throw new ReservaExceptionM04(RecursoAvionCO.CodigoErrorFormulario, RecursoAvionCO.MensajeErrorFomulario, ex);
            }

        }
    }
}