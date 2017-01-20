using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Comida:Entidad
    {
        public string _nombre { get; set; }
        public string _tipo { get; set; }
        public int _estatus { get; set; }
        public string _descripcion { get; set; }

        public Comida(int id, string nombre, string tipo, int estatus, string descripcion) {
            this._id = id;
            this._nombre = nombre;
            this._tipo = tipo;
            this._estatus = estatus;
            this._descripcion = descripcion;
        }

        public Comida(string nombre, string tipo, int estatus, string descripcion)
        {
            this._id = 0;
            this._nombre = nombre;
            this._tipo = tipo;
            this._estatus = estatus;
            this._descripcion = descripcion;
        }

        public Comida(Comida comida) {
            this._id = comida._id;
            this._nombre = comida._nombre;
            this._tipo = comida._tipo;
            this._estatus = comida._estatus;
            this._descripcion = comida._descripcion;
        }

        public Comida()
        {
            this._id = 0;
            this._nombre = "";
            this._tipo = "";
            this._estatus = 0;
            this._descripcion = "";
        }
    }
}