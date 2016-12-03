using FOReserva.Models.Restaurantes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


//IMPORTANTE AGREGAR EL USING DE SUS RESPECTIVAS CLASES PARA PODER AGREGAR EL METODO DE AGREGAR/CONSULTAR

namespace FOReserva.Servicio
{
    public class manejadorSQL
    {
        //Inicializo el string de conexion en el constructor
        public manejadorSQL()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }
        //Atributo que ejecutara la conexion a la bd
        private SqlConnection conexion = null;
        //string que contendra la conexion a la bd
        private string stringDeConexion = null;


        public List<CRestaurantModel> buscarRest()
        {

            conexion = new SqlConnection(stringDeConexion);
            conexion.Open();
            SqlCommand query = conexion.CreateCommand();
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
            return lista_rest;

        }
    }
}