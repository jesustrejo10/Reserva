using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Restaurantes
{
    public class CRestaurantModel : BaseEntity
    {
        private string _address { get; set; }
        private string _description { get; set; }
        private string _open { get; set; }
        private string _close { get; set; }

        public CRestaurantModel
            ( int id, string name, string address, string description,
              string open, string close ) : base ( id, name )
        {
            this._address = address;
            this._description = description;
            this._open = open;
            this._close = close;
        }

    }
}