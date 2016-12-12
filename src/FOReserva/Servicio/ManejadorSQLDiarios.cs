using FOReserva.Models.Diarios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FOReserva.Servicio
{
    /*Clase para manejo de Diarios de Viaje en BD*/
    public class ManejadorSQLDiarios : manejadorSQL
    {
        /*Constructor de manejadorSQL*/
        public ManejadorSQLDiarios() : base() { }
    

    /*BUSQUEDAS*/

    /*Buscar TODOS los DV*/
    public List<CDiarioModel> buscarDV(){
        string query = @"SELECT
	                        id_diar,
	                        nombre_diario,
                            CASE 
                                WHEN len(descripcion_diar)>100
                                THEN LEFT(descripcion_diar, 97) + '...' 
                                ELSE descripcion_diar END descr
                         FROM Diario_Viaje;";
        SqlDataReader read = Executer(query);
        List<CDiarioModel> listaDV = new List<CDiarioModel>();
        if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string desc = read.GetString(2);
                    CDiarioModel diario = new CDiarioModel();
                    diario.Id = id;
                    diario.Nombre = nombre;
                    diario.Descripcion = desc;
                    listaDV.Add(diario);
                }
            }
            CloseConnection();
            return listaDV;
    }  
    
    
    /*INSERTS*/
    
    /*Nuevo Diario*/

             /* public void CrearDiario(Crear_Nuevo_Diario Cvista_Diarios ) {
              string query =
               @"INSERT INTO Diario_Viaje () 
               VALUES()";
               CloseConnection();
               }*/
    }
}