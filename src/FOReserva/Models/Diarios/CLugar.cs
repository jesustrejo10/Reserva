using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.Diarios
{
    public class CLugar
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Tipo { get; set; }

        public List<SelectListItem> diariosLugares()
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CLugar> lugaresCLugar = manejador.obtenerLugares();
            List<SelectListItem> lugares = new List<SelectListItem>();
            lugares.Add(new SelectListItem { Value = "-1", Text = "------ Buscar por destino de viaje ------", Selected = true });
            foreach (CLugar lug in lugaresCLugar)
            {
                SelectListItem l = new SelectListItem { Value = lug.ID.ToString(), Text = (lug.Tipo.Equals("pais") ? "" : "  --- ") + lug.Nombre };
                lugares.Add(l);
            }
            return lugares;
        }
    }


}