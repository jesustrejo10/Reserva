using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_hoteles
{
    public class CGestionHoteles_SelectEstrellasModel
    {
        public int[] _CategoryId { get; set; }
        public MultiSelectList _Categories { get; set; }
    }
}