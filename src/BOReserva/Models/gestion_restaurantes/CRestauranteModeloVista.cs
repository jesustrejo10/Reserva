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

        public int _id { get; set; }
        public int _idLugar { get; set; }
        public string _nombre { get; set; }
        public string _tipoComida { get; set; }
        public string _direccion { get; set; }
        public string _descripcion { get; set; }
        public string _horarioApertura { get; set; }
        public string _horarioCierre { get; set; }
    }
}