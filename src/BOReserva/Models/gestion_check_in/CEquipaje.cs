using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BOReserva.Models.gestion_check_in
{
    public class CEquipaje
    {
        public int _id { get; set; }
        public int _pase { get; set; }
        public int _peso1 { get; set; }
        public int _peso2 { get; set; }

        public int _hdnFlag { get; set; }

        public CEquipaje(int pase) {
            _pase = pase;
            _peso1 = 0;
            _peso2 = 0;
        }

        public CEquipaje(){}
    }
}