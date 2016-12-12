using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.ReservaBoleto
{
    public class CModeloBoleto : BaseEntity
    {

        private string _codigo;
        private DateTime _fecha;
        private float _costo;
        private string _tipo;
        private string _origen;
        private string _destino; 

        public CModeloBoleto
            (int id, string name, string codigo, DateTime fecha, float costo, string tipo, string origen, string destino) : base(id, name)
        {
            this._codigo = codigo;
            this._fecha = fecha;
            this._costo = costo;
            this._tipo = tipo;
            this._origen = origen;
            this._destino = destino;

        }
        /* Constructor Vacio */
        public CModeloBoleto() : base (){ }

        /* codigo de reserva XXXXYYYY*/
        public string codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        /* fecha de la reserva */
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public float costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        /* Metodos Get y Set 
          tipo de reserva (turista,ejecutivo) */
        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string origen
        {
            get { return _origen; }
            set { _origen = value; }
        }

        public string destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

    }
}
