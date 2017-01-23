using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BOReserva.DataAccess.DataAccessObject;
using System.Web.Mvc;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace BOReserva.Models.gestion_boletos
{
    public class CBuscarVuelo
    {
        public CBuscarVuelo() { }

        public String _ida { get; set; }
        public String _vuelta { get; set; }

        [Display(Name = "Ciudad")]
        public int SelectedCiudadIdDestino { get; set; }

        public IEnumerable<SelectListItem> CiudadesDestino
        {
            get
            {
                //var sqlObj = new manejadorSQL_Boletos();
                var sqlObj = (IDAOLugar) FabricaDAO.instanciarDaoLugar();
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
                //var sqlObj = new manejadorSQL_Boletos();
                var sqlObj = (IDAOLugar)FabricaDAO.instanciarDaoLugar();
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
                    Text = "Selecciona Ciudad Origen"
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