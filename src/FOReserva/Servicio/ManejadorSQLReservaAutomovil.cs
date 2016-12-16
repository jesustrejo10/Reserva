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

            try
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
            catch (ManejadorSQLException ErrorBD)
            {
                throw ErrorBD;
            
            }

           }

        /* Buscar autos por ciudad para mostrar resultados*/
        public List<CReserva_Autos_Perfil> buscarAutosCiudad(string CiudadOri, string CiudadDes, string fechaini, string fechafin, string horaini, string horafin)
        {

            try
            {
                int ciudad = Int32.Parse(CiudadOri);
                int ciudadDes = Int32.Parse(CiudadDes);
                string consulta = "SELECT DISTINCT aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_preciocompra, aut_anio, aut_cantpasajeros, aut_disponibilidad FROM Automovil, Reserva_Automovil WHERE aut_disponibilidad=1 and aut_fk_ciudad=" + ciudad + " EXCEPT SELECT DISTINCT aut_matricula, aut_modelo, aut_fabricante, aut_tipovehiculo, aut_color, aut_transmision, aut_fk_ciudad, aut_preciocompra, aut_anio, aut_cantpasajeros, aut_disponibilidad FROM Automovil, Reserva_Automovil WHERE aut_matricula=raut_fk_automovil and raut_estatus=1 and aut_fk_ciudad=" + ciudad;
                SqlDataReader leer = Executer(consulta);
                List<CReserva_Autos_Perfil> list_auto = listarAutomoviles(leer, ciudad, ciudadDes, fechaini, fechafin, horaini, horafin);
                CloseConnection();


                return list_auto;
            }
            catch (ManejadorSQLException ErrorBD)
            {
                throw ErrorBD;
            }
        }

        /* Llenar lista de carros para resultados */
        public List<CReserva_Autos_Perfil> listarAutomoviles(SqlDataReader leer, int CiudadOri, int CiudadDes, string fechaini, string fechafin, string horaini, string horafin)
        {
            List<CReserva_Autos_Perfil> lista_autos = null;
            lista_autos = new List<CReserva_Autos_Perfil>();

            if (leer.HasRows)
            {
                while (leer.Read())
                {
                    string matricula = leer.GetString(0);
                    string modelo = leer.GetString(1);
                    string fabricante = leer.GetString(2);
                    string tipo = leer.GetString(3);
                    string color = leer.GetString(4);
                    string transmision = leer.GetString(5);
                    int ciudad = leer.GetInt32(6);
                    decimal precio = leer.GetDecimal(7);
                    int anio = leer.GetInt32(8);
                    int pasajero = leer.GetInt32(9);
                    int disponibilidad = leer.GetInt32(10);

                    CReserva_Autos_Perfil reserva = new CReserva_Autos_Perfil();
                    reserva.Autos = new CBusquedaModel();
                    reserva.Autos.Matricula = matricula;
                    reserva.Autos.Modelo = modelo;
                    reserva.Autos.Fabricante = fabricante;
                    reserva.Autos.Tipo = tipo;
                    reserva.Autos.Color = color;
                    reserva.Autos.Transmision = transmision;
                    reserva.Autos.Ciudad = ciudad;
                    reserva.Autos.Precio = precio;
                    reserva.Autos.Anio = anio;
                    reserva.Autos.Pasajeros = pasajero;
                    reserva.Autos.Disponibilidad = disponibilidad;

                    reserva.CiudadOri = CiudadOri.ToString();
                    reserva.CiudadDes = CiudadDes.ToString();
                    reserva.FechaIni = fechaini;
                    reserva.FechaFin = fechafin;
                    reserva.HoraIni = horaini;
                    reserva.HoraFin = horafin;

                    lista_autos.Add(reserva);
                }
            }
            return lista_autos;
        }

        // Listar las Reservas de un usuario
        public List<CReserva_Autos_Perfil> buscarReservas()
        {

           
                string consulta = "SELECT raut_id, aut_fabricante, aut_modelo, raut_fecha_ini, raut_fecha_fin, lugarEntrega.lug_nombre, lugarDevolucion.lug_nombre, raut_estatus FROM Automovil, Reserva_Automovil, Usuario, Lugar lugarEntrega, Lugar lugarDevolucion WHERE usu_id=1 and raut_fk_usuario=usu_id and raut_fk_automovil=aut_matricula and raut_fk_ciudad_entrega=lugarEntrega.lug_id and raut_fk_ciudad_devolucion=lugarDevolucion.lug_id ";
            SqlDataReader leer = Executer(consulta);
            List<CReserva_Autos_Perfil> lista_misreservas = new List<CReserva_Autos_Perfil>();
            
            if (leer.HasRows)
            {
                while (leer.Read())
                {
                    int idReserva = leer.GetInt32(0);
                    string fabricante = leer.GetString(1);
                    string modelo = leer.GetString(2);
                    string fechaIni = leer.GetString(3);
                    string fechaFin = leer.GetString(4);
                    string ciudadOri = leer.GetString(5);
                    string ciudadDes = leer.GetString(6);
                    int status = leer.GetInt32(7);

                    CReserva_Autos_Perfil perfil = new CReserva_Autos_Perfil();
                    perfil.IdReserva = idReserva;
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
        
        public void InsertarReservaAuto(CReserva_Autos_Perfil model) {

            try
            {
                int ciudaddes = Int32.Parse(model.CiudadDes);
                int ciudadori = Int32.Parse(model.CiudadOri);
                Random r = new Random();
                int randomid = r.Next(100);
                string query = "INSERT INTO Reserva_Automovil VALUES ("+randomid+",'"+model.FechaIni+"','"+model.FechaFin+"','"+model.HoraIni +"','"+model.HoraFin+"',1,'"+model.Autos.Matricula+"',"+ciudaddes+","+ciudadori+", 1)";
                this.Executer(query);
                CloseConnection();
            }
            catch (ManejadorSQLException ErrorBD)
            {
                throw ErrorBD;
            }
        }

        public void eliminarReserva(int idReserva)
        {
            string query = "UPDATE Reserva_Automovil SET raut_estatus=0 FROM Usuario WHERE usu_id=1 and raut_fk_usuario=usu_id and raut_estatus=1 and raut_id =" + idReserva;
            this.Executer(query);
            CloseConnection();
        }
    }
}