using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain.M06
{
    public class ComidaVuelo:Entidad
    {
        public string _comida { get; set; }
        public string _codigoVuelo{ get; set; }
        public int _cantidad { get; set; }


        public ComidaVuelo(int id, string comida, string codigoVuelo, int cantidad)
        {
            this._id = id;
            this._comida = comida;
            this._codigoVuelo = codigoVuelo;
            this._cantidad = cantidad;
        }
    }
}