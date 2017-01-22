﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_vuelo
{
    public class CVuelo
    {
        public int _id { get; set; }
        public String _codigoVuelo { get; set; }
        public String _ciudadOrigen { get; set; }
        public String _ciudadDestino { get; set; }
        public String _fechaDespegue { get; set; }
        public String _statusVuelo { get; set; }
        public String _fechaAterrizaje { get; set; }
        public String _matriculaAvion { get; set; }


        public CVuelo(int id, String codigovuelo, String ciudadorigen, String ciudaddestino, String fechadespegue, String status, String fechaaterrizaje, String matriculaavion)
        {
            _id = id;
            _codigoVuelo = codigovuelo;
            _ciudadOrigen = ciudadorigen;
            _ciudadDestino = ciudaddestino;
            _fechaDespegue = fechadespegue;
            _statusVuelo = status;
            _fechaAterrizaje = fechaaterrizaje;
            _matriculaAvion = matriculaavion;
        }

        public CVuelo()
        {
        }



    }
}