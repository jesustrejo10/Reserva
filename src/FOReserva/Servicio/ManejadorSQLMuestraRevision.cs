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


        public List<CRevision> ConsultarRevision(string nombre, string apellido)   //se consulta para consultar
        {
            string query = "SELECT rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo, rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us, Reserva_Restaurante as rest where val.rv_id=rev.rev_FK_rev_val_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + apellido + "%') and rev.rev_FK_usu_id=us.usu_id and  rest.FK_USUARIO=us.usu_id and rest.FK_RESTAURANTE=rev.rev_FK_res_res_id";
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

        public List<CRevision> ConsultarRevision2(string restName, CRevision revision)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + restName + "%' )";
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

        public List<CRevision> Eliminar_Revision(string usuario, CRevision revision)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + usuario + "%' '%" + revision + "%')";
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

        public List<CRevision> Crear_Revision(CReservation_Restaurant res, string usuario)   //aca iria el INSERT
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


        public List<CRevision> Crear_RevisionHotel(CReservation_Restaurant res, string usuario, DateTime fecha)   //aca iria el INSERT
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









