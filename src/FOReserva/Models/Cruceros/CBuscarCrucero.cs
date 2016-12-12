using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Servicio;

namespace FOReserva.Models.Cruceros
{
public class CBuscarCrucero
{
	public CBuscarCrucero(){}
    public String _ida { get; set; }
    public String _vuelta { get; set; }

    [Display(Name = "Crucero")]
    public int SelectedCrucero { get; set; }

    public IEnumerable<SelectListItem> Cruceros
    {
        get
        {
            var sqlObj = new manejadorSQLCrucero();
            var allCrucero = sqlObj.buscarCruceros();

            return DefaultCruceroItem.Concat(new SelectList(allCrucero, "Id", "Name"));

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