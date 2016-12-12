using FOReserva.Models.Diarios;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FOReserva.Servicio
{
    /*Clase para manejo de Diarios de Viaje en BD*/
    public class ManejadorSQLDiarios : manejadorSQL
    {
        StringBuilder sb;
        /*Constructor de manejadorSQL*/
        public ManejadorSQLDiarios() : base() { }
    

    /*BUSQUEDAS*/

    /*Buscar TODOS los Diarios de Viaje*/
    public List<CDiarioModel> obtenerDiarios(){
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

    /*Buscar Diarios de Viaje dado un modelo*/
    public List<CDiarioModel> buscarDiarios(CDiarioModel diar)
    {
        string fecha_i = diar.Fecha_ini.ToString("yyyy-MM-dd");
        string fecha_f = diar.Fecha_fin.ToString("yyyy-MM-dd");
        sb = new StringBuilder();
        sb.Append("SELECT ");
        sb.Append(" id_diar, nombre_diario, CASE ");
        sb.Append("  WHEN len(d.descripcion_diar)>100 ");
        sb.Append("  THEN LEFT(d.descripcion_diar, 97) + '...' ");
        sb.Append("  ELSE d.descripcion_diar END descr ");
        sb.Append("FROM Diario_Viaje d, Lugar l ");
        sb.Append("WHERE d.fecha_carga_diar BETWEEN '" + fecha_i + "' AND '" + fecha_f + "' ");
        sb.Append(" AND l.lug_id = " + diar.Destino);
        sb.Append(" AND d.fk_destino = l.lug_id;");
        string query = sb.ToString();
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

    /*Buscar TODOS los Lugares para dropdown*/
    public List<CLugar> obtenerLugares()
    {
        string query = @"SELECT
	                        lug_id,
	                        lug_nombre,
                            lug_tipo_lugar
                         FROM Lugar;";
        SqlDataReader read = Executer(query);
        List<CLugar> listaLugares = new List<CLugar>();
        if (read.HasRows)
        {
            while (read.Read())
            {
                int id = read.GetInt32(0);
                string nombre = read.GetString(1);
                string tipo = read.GetString(2);
                CLugar lug = new CLugar();
                lug.ID = id;
                lug.Nombre = nombre;
                lug.Tipo = tipo;
                listaLugares.Add(lug);
            }
        }
        CloseConnection();
        return listaLugares;
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