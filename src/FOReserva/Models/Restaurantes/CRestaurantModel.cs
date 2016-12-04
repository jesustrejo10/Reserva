using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Restaurantes
{
    /*Clase del modelo Restaurante
      Atributos: 
       _address: Direccion del restaurante
       _description: Descripcion del restaurante
       _open: Hora de apertura del restaurante
       _clese: Hora de cierre
         */
    public class CRestaurantModel : BaseEntity
    {
        private string _address;
        private string _description;
        private string _open;
        private string _close;
        
        /* Constructor Completo */
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

        /* Constructor Vacio */
        public CRestaurantModel() :base (){ }

        /*Direccion del restaurante*/
        public string Addres
        {
            get { return _address; }
            set { _address = value; }
        }

        /* Descripcion del restaurante */
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /* Metodos Get y Set 
          Hora de apertura del restaurante */
        public string Open
        {
            get { return _open; }
            set { _open = value; }
        }

        /* Metodos Get y Set para la hora de cierre 
          del restaurante */
        public string Close
        {
            get { return _close; }
            set { _close = value; }
        }
    }
}