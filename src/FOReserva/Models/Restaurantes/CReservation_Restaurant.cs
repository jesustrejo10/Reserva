
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
        private CRestaurantModel _restaurant;

        /*Constructor Completo*/
        public CReservation_Restaurant
           (string owner, string date, string time, int count, int idUser, int idRestaurant)
           : base( owner, date, time )
        {
            this._count = count;
            this._idUser = idUser;
            this._idRestaurant = idRestaurant;
        }

        /*Constructor Vacio*/
        public CReservation_Restaurant() : base() { }
        
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

