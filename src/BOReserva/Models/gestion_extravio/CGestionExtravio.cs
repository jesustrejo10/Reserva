using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_extravio
{
    public class CGestionExtravio
    {
        //creacion de atributos de la clase
        private int _cantidad;
        private string _descripcion;
        private string _categoria;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
       




    }

    
}