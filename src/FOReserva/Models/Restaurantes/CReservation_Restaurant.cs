
using System.Collections.Generic;
using System.Web.Mvc;
namespace FOReserva.Models.Restaurantes
{
    /*Clase Modelo de la Reservacion de un restaurante
      Atributos:
       _count: Cantidad de personas de la reservacion
       _idUser: id del usuario con el que se realiza la reserva
       _restaurant: Restaurante al que se realiza la reserva
         */
    public class CReservation_Restaurant : ReservationModels
    {

        private int _count;
        private int _idUser;
        private int _idRestaurant;
        private string _time;
        private CRestaurantModel _restaurant;

        public List<SelectListItem> _Time { get; set; }
        public List<SelectListItem> _Count { get; set; }

        /*Constructor Completo*/
        public CReservation_Restaurant
           (string owner, string date, string time, int count, int idUser, int idRestaurant)
           : base( owner, date, time )
        {
            this._count = count;
            this._idUser = idUser;
            this._idRestaurant = idRestaurant;
            this._time = time;


            this._Time = new List<SelectListItem>();
            for (var i = 7; i <= 23; i++)
            {
                this._Time.Add(new SelectListItem()
                {
                    Value = i.ToString() + ":00",
                    Text = i.ToString() + ":00"
                });
            }

            this._Count = new List<SelectListItem>();

            for (var j = 1; j <= 10; j++)
            {
                this._Count.Add(new SelectListItem()
                {
                    Value = j.ToString(),
                    Text = j.ToString() 
                });
            }


        }

        /*Constructor Vacio*/
        public CReservation_Restaurant() : base() {

            this._Time = new List<SelectListItem>();
            for (var i = 7; i <= 23;i++ )
            {
                this._Time.Add(new SelectListItem() { 
                    Value = i.ToString() + ":00",
                    Text = i.ToString() + ":00"
                });
            }

            this._Count = new List<SelectListItem>();
            for (var j = 1; j <= 10; j++)
            {
                this._Count.Add(new SelectListItem()
                {
                    Value = j.ToString(),
                    Text = j.ToString()
                });
            }
        }
        
        /*Metodos Get y Set de la cantidad de personas de la reserva*/
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        /*Id del usuario que se encuentra logeado*/
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }

        public int IdRestaurant
        {
            get { return _idRestaurant; }
            set { _idRestaurant = value; }
        }

        /*
         * Restaurante de la reserva
         */
        public CRestaurantModel Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }

    }
}

