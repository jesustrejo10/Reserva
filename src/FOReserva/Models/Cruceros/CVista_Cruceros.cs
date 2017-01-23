using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Servicio;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando;

namespace FOReserva.Models.Cruceros
{
    public class CVista_Cruceros{

        public CVista_Cruceros(){}

        public String _ida { get; set; }
        public String _vuelta { get; set; }

        [Display(Name = "Crucero")]
        public int SelectedCrucero { get; set; }

        public IEnumerable<SelectListItem> Cruceros
        {
            get
            {
                
                Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.crearM22ReservaCruceroTodos();
                List<Entidad> cruceros = comando.ejecutar();

                return DefaultCruceroItem.Concat(new SelectList(cruceros, "Id", "Name"));
               

            }
        }
        public IEnumerable<SelectListItem> DefaultCruceroItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Seleccione un Crucero"
                }, count: 1);
            }
        }
    
    
    
    
    }

   
}