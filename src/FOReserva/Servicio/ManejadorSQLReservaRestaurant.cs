using FOReserva.Models.Restaurantes;
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
            List<CRestaurantModel> lista_rest = new List<CRestaurantModel>();
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
            CloseConnection();
            return lista_rest;
        }

        /* Buscar restaurante por ciudad */
        public List<CRestaurantModel> buscarRestCity(string cityName)
        {
            string query = "SELECT res.rst_id ,res.rst_nombre ,res.rst_direccion, lug.lug_nombre  FROM Restaurante as res, Lugar as lug where res.fk_lugar = lug.lug_id and lug.lug_tipo_lugar = 'ciudad' and LOWER(lug.lug_nombre) LIKE LOWER('%" + cityName + "%')"; 
            SqlDataReader read = Executer(query);
            List<CRestaurantModel> lista_rest = new List<CRestaurantModel>();
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
            CloseConnection();
            return lista_rest;
        }

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


        
        public void CrearReserva(CReservation_Restaurant reserva)
        {

            string query = "INSERT INTO Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( '"+reserva.Name+"',convert(date, '"+reserva.Date+"'),'"+reserva.Time+"',"+reserva.Count+","+reserva.IdRestaurant+", 2)";
            this.Executer(query);
            CloseConnection();
        }
    }
}