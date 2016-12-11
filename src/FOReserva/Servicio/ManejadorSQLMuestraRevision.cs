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

        public List<CRevision> ConsultarRevision2(string nombre, string apellido, int revision) //consulta para eliminar
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

        public List<CRevision> Eliminar_Revision(string nombre, string apellido,  int revision)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + nombre + "%' '%" + apellido + "%' '%" + revision + "%')";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())                        //agregar aca los campos de la clase CRevision
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

        public List<CRevision> Crear_RevisionRestaurant(int reserva, string nombre , string apellido)   //INSERT
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + usuario + "%' '%" + usuario + "%')";
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

        public List<CRevision> Crear_RevisionHotel(int reserva, string nombre, string apellido)   //INSERT
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + usuario + "%' '%" + usuario + "%''%" + fecha + "%')";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())                        //agregar aca los campos de la clase CRevision
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


    }


}









