using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Servicio;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FOReserva.Models.Autos
{
    public class Cvista_ReservaAutos
    {
        public String _prueba { get; set; }
        public DateTime fechaini { get; set; }
        public DateTime fechafin { get; set; }
        public String horaini {get; set;}
        public String horafin { get; set; }

               [Display(Name = "Ciudad")]

            public int SelectedCiudadIdDestino { get; set; }

            public IEnumerable<SelectListItem> CiudadesDestino
            {
                get
                {
                    var sqlObj = new ManejadorSQLReservaAutomovil();
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
                    var sqlObj = new ManejadorSQLReservaAutomovil();
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
                        Text = "Selecciona Ciudad Entrega"
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
                        Text = "Selecciona Ciudad Devolucion"
                    },count: 1);
                }
            }
        }


    
 }
