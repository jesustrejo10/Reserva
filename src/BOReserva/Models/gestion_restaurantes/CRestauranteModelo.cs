using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_restaurantes
{
    public class CRestauranteModelo
    {
        public int _id { get; set; }
        public string _nombre { get; set; }
        public string _tipoComida { get; set; }
        public string _direccion { get; set; }
        public string _descripcion { get; set; }
        public string _horarioApertura { get; set; }
        public string _horarioCierre { get; set; }

        /* Constructor por defecto */

        public CRestauranteModelo() { }

        /* Constructor completo */

        public CRestauranteModelo(int id, string nombre, string tipoComida, string direccion, string descripcion, string horarioApertura, string horarioCierre)
        {
            this._id = id;
            this._nombre = nombre;
            this._tipoComida = tipoComida;
            this._direccion = direccion;
            this._descripcion = descripcion;
            this._horarioApertura = horarioApertura;
            this._horarioCierre = _horarioCierre;
        }
    }
}