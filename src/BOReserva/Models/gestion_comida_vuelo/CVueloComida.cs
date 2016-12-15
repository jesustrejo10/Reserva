using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CVueloComida
    {
        public int _id { get; set; }
        public string _codigoVuelo { get; set; }
        public string _nombrePlato { get; set; }
        public int _cantidadComida { get; set; }

            public CVueloComida() { }
            public CVueloComida(int id,string cvuelo, string nombre,int cantidad)
                {
                        _id = id;
                        _codigoVuelo = cvuelo;
                        _nombrePlato = nombre;
                        _cantidadComida = cantidad;

                }
    }
}