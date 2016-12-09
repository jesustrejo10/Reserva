using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_lugares;

namespace BOReserva.Models.gestion_restaurantes
{
    public class CRestauranteModeloVista
    {
        public List<CRestauranteModelo> _listaRestaurantes { get; set; }
        public List<CLugarModelo> _listaCiudades { get; set; }
        public string _estado { get; set; }
    }
}