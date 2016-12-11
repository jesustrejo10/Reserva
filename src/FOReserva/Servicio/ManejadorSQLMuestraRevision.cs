using System;
using System.Collections.Generic;
using System.Linq;
using FOReserva.Models.Revision;
using System.Data.SqlClient;
using FOReserva.Models.Restaurantes;


namespace FOReserva.Servicio
{
    public class ManejadorSQLMuestraRevision : manejadorSQL
    {


        public ManejadorSQLMuestraRevision() : base() { }


        public List<CRevision> ConsultarRevision(string nombre, string apellido)  
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + nombre + "%' '%" + apellido + "%')";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())                        
                {
                   DateTime _fecha = read.GetDateTime(0);
                    string _mensaje = read.GetString(1);
                    int _tipo= read.GetInt32(2);
                    int _puntuacion = read.GetInt32(3);
                   // int _valoracion = read.GetInt32(4);
                    CRevision rev = new CRevision();
                   // CRevisionValoracion reva = new CRevisionValoracion();
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                  //  reva. = _valoracion;
                    lista_rev.Add(rev);

                     
               
       
            
        


                }
            }
            CloseConnection();
            return lista_rev;
        }

        public List<CRevision> ConsultarRevision2(string nombre, string apellido, int revision)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + nombre + "%' '%" + apellido + "%' '%" + revision + "%')";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    DateTime _fecha = read.GetDateTime(0);
                    string _mensaje = read.GetString(1);
                    int _tipo = read.GetInt32(2);
                    int _puntuacion = read.GetInt32(3);
                    // int _valoracion = read.GetInt32(4);
                    CRevision rev = new CRevision();
                    // CRevisionValoracion reva = new CRevisionValoracion();
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    //  reva. = _valoracion;
                    lista_rev.Add(rev);








                }
            }
            CloseConnection();
            return lista_rev;
        }

        public void Eliminar_Revision(string nombre, string apellido, int revision)
        {
            string query = "DELETE FROM Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
        }

        public void Crear_Revision(string nombre, string apellido, int reserva)   
        {
            string query = "INSERT INTO Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
        }

        public void Editar_Revision(string nombre, string apellido, int revision)
        {
            string query = "UPDATE FROM Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
        }




    }


}









