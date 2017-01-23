using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_vuelo
{
    public class CrearVueloMO : VueloViewModel
    {

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
            if (_fechaDespegue != null && _horaDespegue != null)
                fechaDespegue = Convert.ToDateTime((_fechaDespegue + " " + _horaDespegue));
            else
                throw new ArgumentNullException();
        }

        public DateTime getFechaAterrizaje()
        {
            if (_fechaAterrizaje != null && _horaAterrizaje != null)
                return (Convert.ToDateTime((_fechaAterrizaje + " " + _horaAterrizaje)));
            throw new ArgumentNullException();
        }
    }
}