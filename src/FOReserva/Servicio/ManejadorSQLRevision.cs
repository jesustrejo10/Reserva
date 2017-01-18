
using System;
using System.Collections.Generic;
using FOReserva.Models.Revision;
using FOReserva.Models.Restaurantes;
using System.Data.SqlClient;
using static FOReserva.Models.Revision.CRevision;

namespace FOReserva.Servicio
{
    /// <summary>
    /// Clase para el manejo Revisiones en BD
    /// </summary>
    public class ManejadorSQLRevision : manejadorSQL
    {



        public ManejadorSQLRevision() : base() { }


        /*Buscar Revision por Usuario*/
       
        public List<CRevision> ConsultarRevision(string restName)   //se consulta para eliminar
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + restName + "%')";

            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())                        //agregar aca los campos de la clase CRevision
                {

                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    int tipo = read.GetInt32(2);
                    CRevision rev = new CRevision();
                    rev.Id = id;
                    rev.Name = nombre;
                    rev.Tipo = tipo;
                    lista_rev.Add(rev);
                }
            }
            CloseConnection();
            return lista_rev;
        }

       

        public bool Crear_Revision(string rev_mensaje, int rev_puntuacion)   //FALTA
        {
            string query = "INSERT INTO Revision (rev_fecha, rev_mensaje, rev_tipo, rev_puntuacion, rev_FK_usu_id, rev_FK_res_hot_id, rev_FK_res_res_id) VALUES('2016/12/10','" + rev_mensaje + "',1,'" + rev_puntuacion + "',1,null,46);";
            this.Executer(query);
            CloseConnection();
            return true;
        }


        public void Eliminar_Revision(int Id)
        {
            string query = "DELETE revisión where rev_id in (select rev_id from Revision where rev_id =" + Id + ")";
            this.Executer(query);
                 
            CloseConnection();
            
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
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    int tipo = read.GetInt32(2);
                    CRevision rev = new CRevision();
                    rev.Id = id;
                    rev.Name = nombre;
                    rev.Tipo = tipo;
                    lista_rev.Add(rev);
                }
            }
            CloseConnection();
            return lista_rev;
        }

        /// <summary>
        /// Metodo para listar revisiones guardadas
        /// </summary>
        /// <returns>Lista de revisiones</returns>
        public List<CRevision> BuscarRevisiones(int revision)
        {

            string query = "SELECT rest.rst_id, rev.rev_fecha, rev.rev_mensaje, rev.rev_puntuacion FROM Restaurante as rest, Reserva_Restaurante as res, Revision as rev  WHERE rev.rev_tipo=1 and rev.rev_FK_res_res_id=res.ID and rest.rst_id=res.FK_RESTAURANTE and rest.rst_id= " + revision ;
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    int _Id = read.GetInt32(0);
                    
                   DateTime _fecha = read.GetDateTime(1);
                    string _mensaje = read.GetString(2);
                    int _puntuacion = read.GetInt32(3);
                    CRevision rev = new CRevision();
                    rev.Id = _Id;
                   rev.Fecha = _fecha;
                    
                    rev.Mensaje = _mensaje;
                    //rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    lista_rev.Add(rev);
                }
                return lista_rev;
            }
            return null;
        }

        public List<CRevision> BuscarRevisionesUsuario()
        {

            string query = "SELECT rest.rst_id, rev.rev_fecha, rev.rev_mensaje, rev.rev_puntuacion FROM Restaurante as rest, Reserva_Restaurante as res, Revision as rev  and rev.rev_FK_res_res_id=res.ID and rest.rst_id=res.FK_RESTAURANTE ";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    int _Id = read.GetInt32(0);

                    DateTime _fecha = read.GetDateTime(1);
                    string _mensaje = read.GetString(2);
                    int _puntuacion = read.GetInt32(3);
                    CRevision rev = new CRevision();
                    rev.Id = _Id;
                    rev.Fecha = _fecha;

                    rev.Mensaje = _mensaje;
                    //rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    lista_rev.Add(rev);
                }
                return lista_rev;
            }
            return null;
        }
    }


}




