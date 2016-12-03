using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Restaurantes
{
    public class CRestaurantModel : BaseEntity
    {
        private string _address;

        public string Addres
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _open;

        public string Open
        {
            get { return _open; }
            set { _open = value; }
        }
        private string _close;

        public string Close
        {
            get { return _close; }
            set { _close = value; }
        }

        public CRestaurantModel
            (int id, string name, string address, string description,
              string open, string close)
            : base(id, name)
        {

            this._address = address;
            this._description = description;
            this._open = open;
            this._close = close;
        }

        public CRestaurantModel() :base (){
        
        }

    }
}