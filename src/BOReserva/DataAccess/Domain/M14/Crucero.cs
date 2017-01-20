﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Crucero : Transporte
    {
        //public int _idCrucero { get; set; }

        public String _nombreCrucero { get; set; }

        public String _companiaCrucero { get; set; }

        public int _capacidadCrucero { get; set; }

        public String _estatus { get; set; }

        public String _imagen { get; set; }

        public Crucero() { }

        public Crucero(String nombre, String compania, int capacidad, String estatus) {            
            this._nombreCrucero = nombre;
            this._companiaCrucero = compania;
            this._capacidadCrucero = capacidad;
            this._estatus = estatus;
        }

    }
}