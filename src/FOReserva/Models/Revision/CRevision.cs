using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    public class CRevision : BaseEntity
    {
        private DateTime _fecha;
        private string _descripcion;
        private int _puntuacion;
        private CRevisionValoracion _valoracion;
        private string _tipo;



        public CRevision(int id, string name, DateTime fecha, string descripcion, int puntuacion, int positivo, int negativo, string tipo)
            : base(id, name)
        {

             this._valoracion = new CRevisionValoracion(positivo, negativo);
             this._fecha = fecha;
             this._descripcion = descripcion;
             this._puntuacion = puntuacion;
             this._tipo = tipo;




        }

        public CRevision() : base(){}

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int Puntuacion
        {
            get { return _puntuacion; }
            set { _puntuacion = value; }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

    }
}