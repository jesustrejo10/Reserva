using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Servicio;
using System.Data.SqlClient;

namespace BOReserva.Models.gestion_ruta_comercial
{
    public class CGestion_ruta
    {
        public int _idRuta { get; set; }

        public String _origenRuta { get; set; }

        public String _destinoRuta { get; set; }

        public String _tipoRuta { get; set; }

        public int _distanciaRuta { get; set; }
        public String _rutaCrucero { get; set; }

    }

}