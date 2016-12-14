using FOReserva.Models.Restaurantes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FOReserva.Servicio
{
    /*Clase para el manejo Reservas de restaurantes en DB*/
    public class ManejadorSQLReservaRestaurant : manejadorSQL
    {
        /*Constructor del ManejadorSQL para Reservas*/
        public ManejadorSQLReservaRestaurant() : base() { }

        /*Buscar Restaurantes por Nombre*/
        public List<CRestaurantModel> buscarRestName(string restName)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion, lug.lug_nombre From Restaurante, Lugar as lug where LOWER(rst_nombre) LIKE LOWER('%" + restName + "%') and fk_lugar = lug.lug_id";
            SqlDataReader read = Executer(query);
            List<CRestaurantModel> lista_rest = listarRestaurante(read);
            CloseConnection();
            return lista_rest;
        }

        /* Buscar restaurante por ciudad */
        public List<CRestaurantModel> buscarRestCity(string cityName)
        {
            string query = "SELECT res.rst_id ,res.rst_nombre ,res.rst_direccion, lug.lug_nombre  FROM Restaurante as res, Lugar as lug where res.fk_lugar = lug.lug_id and lug.lug_tipo_lugar = 'ciudad' and LOWER(lug.lug_nombre) LIKE LOWER('%" + cityName + "%')"; 
            SqlDataReader read = Executer(query);
            List<CRestaurantModel> lista_rest = listarRestaurante(read);
            CloseConnection();
            return lista_rest;
        }

        /*Metodo de busqueda del restaurante en la DB*/
        public CRestaurantModel buscarRest(int rest_id)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion, rst_descripcion, lug_nombre From Restaurante, lugar where rst_id=" + rest_id + "and fk_lugar = lug_id";
            SqlDataReader read = Executer(query);
            CRestaurantModel rest = new CRestaurantModel();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string dir = read.GetString(2);
                    string descripcion = read.GetString(3);
                    string city = read.GetString(4);
                    rest.Id = id;
                    rest.Name = nombre;
                    rest.Description = descripcion;
                    rest.Addres = dir;
                    rest.CityName = city;
                }
            }
            CloseConnection();
            return rest;
        }

        /*Metodo para llenar la lista de restaurantes*/
        public List<CRestaurantModel> listarRestaurante(SqlDataReader read)
        {
            List<CRestaurantModel> lista_rest = null;
            lista_rest = new List<CRestaurantModel>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string dir = read.GetString(2);
                    string city = read.GetString(3);
                    CRestaurantModel resta = new CRestaurantModel();
                    resta.Id = id;
                    resta.Name = nombre;
                    resta.Addres = dir;
                    resta.CityName = city;
                    lista_rest.Add(resta);
                }
            }
            return lista_rest;
        }

        /*Metodo que crea una reserva*/
        public void CrearReserva(CReservation_Restaurant reserva)
        {
            string query = "INSERT INTO Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( '"+reserva.Name+"',convert(date, '"+reserva.Date+"'),'"+reserva.Time+"',"+reserva.Count+","+reserva.IdRestaurant+", 1)";
            this.Executer(query);
            CloseConnection();
        }

        /* Metodo para buscar la lista de reservas de un usuario
          userID = id del usuario logeado *
             */
        public List<CReservation_Restaurant> buscarReservas() {
            string query = "Select ID, Reserva_Nombre, Fecha, Hora, Cantidad_Personas, rst_nombre from reserva_restaurante, restaurante where FK_RESTAURANTE = rst_id";
            SqlDataReader read = Executer(query);
            List<CReservation_Restaurant> lista_rest = new List<CReservation_Restaurant>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre_reserva = read.GetString(1);
                    string fecha = read.GetDateTime(2).ToString("yyyy-MM-dd");
                    string hora = read.GetString(3);
                    int cantidad = read.GetInt32(4);
                    string name_rest = read.GetString(5);
                    CReservation_Restaurant reserv = new CReservation_Restaurant();
                    reserv.Id = id;
                    reserv.Name = nombre_reserva;
                    reserv.Date = fecha;
                    reserv.Time = hora;
                    reserv.Count = cantidad;
                    reserv.Restaurant = new CRestaurantModel();
                    reserv.Restaurant.Name = name_rest;
                    lista_rest.Add(reserv);
                }
            }
            return lista_rest;
        }

        /*Metodo para eliminar una reserva
         *  idReserva: ID de la reserva a eliminar
         */
        public void eliminarReserva(int idReserva)
        {
            string query = "DELETE FROM Revision_Valoracion where rv_FK_rev in (select rev_id from Revision where rev_FK_res_res_id =" + idReserva +")";
            this.Executer(query);
            query = "Delete from Revision where rev_FK_res_res_id =" + idReserva;
            this.Executer(query);
            query = "DELETE FROM Reserva_Restaurante WHERE ID = "+idReserva;
            this.Executer(query);
            CloseConnection();
        }

        /*
         *  Metodo para actualizar datos de la reserva
         */
        public void actualizarReserva(CReservation_Restaurant reserva)
        {
            string query = "update Reserva_restaurante set reserva_nombre = '"+reserva.Name+"', fecha = convert(date, '"+reserva.Date+"'), hora = '"+reserva.Time+"', cantidad_personas ="+reserva.Count+" where ID ="+ reserva.Id;
            this.Executer(query);
            CloseConnection();
        }
    }
}