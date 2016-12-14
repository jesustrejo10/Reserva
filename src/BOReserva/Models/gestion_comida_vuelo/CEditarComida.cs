<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CEditarComida
    {
        public int _id { get; set; }
        public String _nombrePlato { get; set; }
        public String _tipoPlato { get; set; }
        public int _estatusPlato { get; set; }
        public String _descripcionPlato { get; set; }

        //Constructor por default por si acaso
        //public CEditarComida() { }

        //Constructor para pasarle los valores a la vista
        public CEditarComida(CComida comida)
        {
            _id = comida._id;
            _nombrePlato = comida._nombrePlato;
            _tipoPlato = comida._tipoPlato;
            _estatusPlato = comida._estatusPlato;
            _descripcionPlato = comida._descripcionPlato;
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CEditarComida
    {
        public int _id { get; set; }
        public String _nombrePlato { get; set; }
        public String _tipoPlato { get; set; }
        public int _estatusPlato { get; set; }
        public String _descripcionPlato { get; set; }

        //Constructor por default por si acaso
        //public CEditarComida() { }

        //Constructor para pasarle los valores a la vista
        public CEditarComida(CComida comida)
        {
            _id = comida._id;
            _nombrePlato = comida._nombrePlato;
            _tipoPlato = comida._tipoPlato;
            _estatusPlato = comida._estatusPlato;
            _descripcionPlato = comida._descripcionPlato;
        }
    }
>>>>>>> Develop
}