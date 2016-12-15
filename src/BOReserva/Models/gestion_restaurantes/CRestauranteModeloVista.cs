using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_lugares;

namespace BOReserva.Models.gestion_restaurantes
{
    /// <summary>
    /// Clase modelo integradora para las vistas parciales de restaurante.
    /// </summary>
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

        public List<string> _horarioLista { get; set; }

        public CRestauranteModeloVista()
        {
            this._horarioLista = new List<string>{ "07:00", "08:00", "09:00", "10:00", "11:00",
                "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00",
            "21:00", "22:00", "23:00", "00:00" };
        }
    }
}