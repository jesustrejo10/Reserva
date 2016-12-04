using FOReserva.Models.Restaurantes;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FOReserva.Servicio
{
    /*Clase para el manejo Reservas de restaurantes en DB*/
    public class ManejadorSQLReserva : manejadorSQL
    {
        /*Constructor del ManejadorSQL para Reservas*/
        public ManejadorSQLReserva() : base() { }

        /*Buscar Restaurantes por Nombre*/
        public List<CRestaurantModel> buscarRestName(/*string restName*/)
        {
            OpenConextion();
            SqlCommand query = this.Conexion.CreateCommand();
            query.CommandText = "Select rst_id, rst_nombre, rst_direccion From Restaurante";
            SqlDataReader read = query.ExecuteReader();
            List<CRestaurantModel> lista_rest = new List<CRestaurantModel>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    string nombre = read.GetString(1);
                    string dir = read.GetString(2);
                    CRestaurantModel resta = new CRestaurantModel();
                    resta.Name = nombre;
                    resta.Addres = dir;
                    lista_rest.Add(resta);
                }
            }
            CloseConextion();
            return lista_rest;
        }

        /* Buscar restaurante por ciudad */
        public List<CRestaurantModel> buscarRestCity()
        {
            return null;
        }

        public void CrearReserva(CReservation_Restaurant reserva)
        {
            OpenConextion();
            SqlCommand query = this.Conexion.CreateCommand();
            query.CommandText =
            @"INSERT INTO Reserva ( Tipo, Reserva_Nombre, Fecha, Hora,
            Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) 
            VALUES('"+reserva.GetType()+@"','"+reserva.Name+@"',
            convert(date, '2016-12-20'), '"+reserva.Time+"',"+reserva.Count+","+
            @"1, 4)";
            CloseConextion();
        }
    }
}