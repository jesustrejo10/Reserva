using FOReserva.Models.Restaurantes;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FOReserva.Servicio
{
    public class ManejadorSQLReserva : manejadorSQL
    {

        public ManejadorSQLReserva() : base() { }

        public List<CRestaurantModel> buscarRest()
        {
            OpenConextion();
            SqlCommand query = this.Conexion.CreateCommand();
            query.CommandText = "Select * From Restaurante";
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
    }
}