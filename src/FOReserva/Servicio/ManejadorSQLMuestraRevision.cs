using System;
using System.Collections.Generic;
using System.Linq;
using FOReserva.Models.Revision;
using System.Data.SqlClient;


namespace FOReserva.Servicio
{
    public class ManejadorSQLMuestraRevision : manejadorSQL
    {


         public ManejadorSQLMuestraRevision() : base() { }


         /*Buscar Revision por Usuario*/                        // tome esto de prueba de la parte de alexander
         public List<CRevision> buscarRestName(string restName)
         {
             string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(rst_nombre) LIKE LOWER('%" + restName + "%')";
             SqlDataReader read = Executer(query);
             List<CRevision> lista_rest = new List<CRevision>();
             if (read.HasRows)
             {
                 while (read.Read())                        //agregar aca los campos de la clase CRevision
                 {
                     int id = read.GetInt32(0);
                     string nombre = read.GetString(1);
                     string tipo = read.GetString(2);
                     CRevision rev = new CRevision();
                     rev.Id = id;
                     rev.Name = nombre;
                     rev.Tipo = tipo;
                     lista_rest.Add(rev);
                 }
             }
             CloseConextion();
             return lista_rest;
         }




    }
}