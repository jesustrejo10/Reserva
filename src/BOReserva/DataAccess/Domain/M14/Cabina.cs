using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Cabina : Entidad
    {
        public Cabina() { }        

        public String _nombreCabina { get; set; }
        public float _precioCabina { get; set; }
        public String _estatus { get; set; }        
        public int _fkCrucero { get; set; }
        public string _nombreCrucero { get; set; }

        public Cabina(int id,String nombre, float precio, String estatus, int crucero)
        {
            _nombreCabina = nombre;
            _precioCabina = precio;
            _estatus = estatus;
            _fkCrucero = crucero;
            _id = id;
        }

        public Cabina(String nombre, float precio, String estatus, string nomcrucero)
        {
            _nombreCabina = nombre;
            _precioCabina = precio;
            _estatus = estatus;
            _nombreCrucero = nomcrucero;
        }
    }
}