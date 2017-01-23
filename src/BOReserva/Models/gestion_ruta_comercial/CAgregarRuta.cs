using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Models.gestion_ruta_comercial
{
    public class CAgregarRuta
    {

        public int _idRuta { get; set; }

        public String _origenRuta { get; set; }

        public String _destinoRuta { get; set; }

        public IEnumerable<SelectListItem> _lorigenRuta { get; set; }

        public IEnumerable<SelectListItem> _ldestinoRuta { get; set; }

        public String _tipoRuta { get; set; }

        public String _estadoRuta { get; set; }

        public int _distanciaRuta { get; set; }

    }
}