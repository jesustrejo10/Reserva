using FOReserva.Models.Autos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System;


namespace FOReserva.Servicio
{

    /*Clase para el manejo Reservas de Automoviles en DB*/
    public class ManejadorSQLReservaAutomovil : manejadorSQL
    {
        /* Buscar ciudad para llenar combobox */
        public List<CLugar> buscarCiudades() 
        {
          List<CLugar> ciudades = new List<CLugar>();
          string consulta = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";
          SqlDataReader reader = Executer(consulta);

                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                       //  Read advances to the next row.
                        while (reader.Read())
                        {
                            var text = reader.GetString(reader.GetOrdinal("lug_nombre"));
                            var id = reader.GetInt32(reader.GetOrdinal("lug_id"));
                            ciudades.Add(new CLugar(id.ToString(), text));
                        }     
                        CloseConnection(); 
                    }
                    return ciudades;
           }

        /* Buscar autos por ciudad para mostrar resultados*/
        public List<CBusquedaModel> buscarAutosCiudad (string CiudadOri, string CiudadDes)
        {
            string consulta = "Select aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_preciocompra, aut_anio, aut_cantpasajeros, aut_disponibilidad From Automovil, Reserva_Automovil, Lugar Where aut_matricula != raut_fk_automovil and aut_disponibilidad=1 EXCEPT Select aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_preciocompra, aut_anio, aut_cantpasajeros, aut_disponibilidad From Automovil, Reserva_Automovil, Lugar Where aut_matricula = raut_fk_automovil and aut_disponibilidad=1 and raut_estatus!=1 ORDER BY aut_matricula";
            
            SqlDataReader leer = Executer(consulta);
            List<CBusquedaModel> list_auto = listarAutomoviles(leer);
            CloseConnection();

            return list_auto;
        }

        /* Llenar lista de carros para resultados */
        public List<CBusquedaModel> listarAutomoviles(SqlDataReader leer)
        {
            List<CBusquedaModel> lista_autos = null;
            lista_autos = new List<CBusquedaModel>();

            if (leer.HasRows)
            {
                while (leer.Read())
                {
                    string modelo = leer.GetString(0);
                    int fk_ciudad = leer.GetInt32(1);

                    CBusquedaModel autos = new CBusquedaModel();
                    autos.Modelo = modelo;
                    autos.Ciudad = fk_ciudad;
                    lista_autos.Add(autos);
                }
            }
            return lista_autos;
        }

        public List<CReserva_Autos_Perfil> buscarReservas()
        {
            string consulta = "SELECT raut_id, aut_fabricante, aut_modelo, raut_fecha_ini, raut_fecha_fin, lugarEntrega.lug_nombre, lugarDevolucion.lug_nombre, raut_estatus FROM Automovil, Reserva_Automovil, Usuario, Lugar lugarEntrega, Lugar lugarDevolucion WHERE usu_id=1 and raut_fk_usuario=usu_id and raut_fk_automovil=aut_matricula and raut_fk_ciudad_entrega=lugarEntrega.lug_id and raut_fk_ciudad_devolucion=lugarDevolucion.lug_id";
            SqlDataReader leer = Executer(consulta);
            List<CReserva_Autos_Perfil> lista_misreservas = new List<CReserva_Autos_Perfil>();

            if (leer.HasRows)
            {
                while (leer.Read())
                {
                    int id = leer.GetInt32(0);
                    string fabricante = leer.GetString(1);
                    string modelo = leer.GetString(2);
                    string fechaIni = leer.GetString(3);
                    string fechaFin = leer.GetString(4);
                    string ciudadOri = leer.GetString(5);
                    string ciudadDes = leer.GetString(6);
                    int status = leer.GetInt32(7);

                    CReserva_Autos_Perfil perfil = new CReserva_Autos_Perfil();
                    perfil.IdReserva= id;
                    perfil.Autos = new CBusquedaModel();
                    perfil.Autos.Fabricante = fabricante;
                    perfil.Autos.Modelo = modelo;
                    perfil.FechaIni = fechaIni;
                    perfil.FechaFin = fechaFin;
                    perfil.CiudadOri = ciudadOri;
                    perfil.CiudadDes = ciudadDes;
                    perfil.Status = status;

                    lista_misreservas.Add(perfil);
                }
            }
            return lista_misreservas;
        }

        public Boolean InsertarReservaAuto(CAgregarReserva model) {


            return true;
        }


    }
}