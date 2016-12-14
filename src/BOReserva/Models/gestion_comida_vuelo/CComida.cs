<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CComida
    {
        public int _id { get; set; }
        public String _nombrePlato { get; set; }
        public String _tipoPlato { get; set; }
        public int _estatusPlato { get; set; }
        public String _descripcionPlato { get; set; }

            public CComida() { }
            public CComida(int id,string nombre,string tipo,int estatus,string descripcion)
                {
                        _id = id;
                        _nombrePlato = nombre;
                        _tipoPlato = tipo;
                        _estatusPlato = estatus;
                        _descripcionPlato = descripcion;
                }
        
    }

   
   
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CComida
    {
        public int _id { get; set; }
        public String _nombrePlato { get; set; }
        public String _tipoPlato { get; set; }
        public int _estatusPlato { get; set; }
        public String _descripcionPlato { get; set; }

            public CComida() { }
            public CComida(int id,string nombre,string tipo,int estatus,string descripcion)
                {
                        _id = id;
                        _nombrePlato = nombre;
                        _tipoPlato = tipo;
                        _estatusPlato = estatus;
                        _descripcionPlato = descripcion;
                }
        
    }

   
   
>>>>>>> Develop
}