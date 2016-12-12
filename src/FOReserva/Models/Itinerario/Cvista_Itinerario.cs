using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Servicio;
using System.ComponentModel.DataAnnotations;

namespace FOReserva.Models.Itinerario
{
    public class Cvista_Itinerario
    {
        public Cvista_Itinerario() { }

        public String _ida { get; set; }
        public String _vuelta { get; set; }

        [Display(Name = "Ciudad")]
        public int SelectedCiudadIdDestino { get; set; }

        public IEnumerable<SelectListItem> CiudadesDestino
        {
            get
            {
                var sqlObj = new ManejadorSQLItinerario();
                var allCiudades = sqlObj.buscarCiudades();

                return DefaultCiudadDestinoItem.Concat(new SelectList(allCiudades, "Id", "Name"));

            }
        }

        [Display(Name = "Ciudad")]
        public int SelectedCiudadIdOrigen { get; set; }

        public IEnumerable<SelectListItem> CiudadesOrigen
        {
            get
            {
                var sqlObj = new ManejadorSQLItinerario();
                var allCiudades = sqlObj.buscarCiudades();

                return DefaultCiudadOrigenItem.Concat(new SelectList(allCiudades, "Id", "Name"));

            }
        }



        public IEnumerable<SelectListItem> DefaultCiudadOrigenItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Selecciona Tu Destino"
                }, count: 1);
            }
        }

        public IEnumerable<SelectListItem> DefaultCiudadDestinoItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Selecciona Ciudad Destino"
                }, count: 1);
            }
        }

    }


}