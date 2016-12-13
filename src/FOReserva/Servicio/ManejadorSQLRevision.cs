using System;
using System.Collections.Generic;
using FOReserva.Models.Revision;
using FOReserva.Models.Restaurantes;
using System.Data.SqlClient;


namespace FOReserva.Servicio
{
    /// <summary>
    /// Clase para el manejo Revisiones en BD
    /// </summary>
    public class ManejadorSQLRevision : manejadorSQL
    {
<<<<<<< HEAD
        public ManejadorSQLRevision() : base() { }

        public List<MostrarRevision> Consultar_Revision(string nombre, string apellido)
        {

            string query = "SELECT rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo, rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us where val.rv_FK_rev=rev.rev_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + apellido + "%') and rev.rev_FK_usu_id=us.usu_id";
=======


        public ManejadorSQLRevision() : base() { }


        /*Buscar Revision por Usuario*/
       
        public List<CRevision> ConsultarRevision(string restName)   //se consulta para eliminar
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + restName + "%')";
>>>>>>> refs/remotes/origin/Develop
            SqlDataReader read = Executer(query);
            List<MostrarRevision> lista_rev = new List<MostrarRevision>();
            if (read.HasRows)
            {
                while (read.Read())                        //agregar aca los campos de la clase CRevision
                {
<<<<<<< HEAD
                    DateTime _fecha = read.GetDateTime(0);
                    string _mensaje = read.GetString(1);
                    int _tipo = read.GetInt32(2);
                    int _puntuacion = read.GetInt32(3);
                    // int _valoracion = read.GetInt32(4);
                    MostrarRevision rev = new MostrarRevision();
                    // CRevisionValoracion reva = new CRevisionValoracion();
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    //  reva. = _valoracion;
=======
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string tipo = read.GetString(2);
                    CRevision rev = new CRevision();
                    rev.Id = id;
                    rev.Name = nombre;
                    rev.Tipo = tipo;
>>>>>>> refs/remotes/origin/Develop
                    lista_rev.Add(rev);
                }
            }
            CloseConnection();
            return lista_rev;
        }

<<<<<<< HEAD
        public bool Eliminar_Revision(string nombre, string apellido, int revision)   //FALTA
        {
            string query = "DELETE FROM Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
            return true;
        }

        public bool Crear_Revision()   //FALTA
        {
            string query = "INSERT INTO Revision (rev_fecha, rev_mensaje, rev_tipo, rev_puntuacion, rev_FK_usu_id, rev_FK_res_hot_id, rev_FK_res_res_id) VALUES('2016/12/10','Comida exquisita',1,10,70,null,46);";
            this.Executer(query);
=======
        public List<CRevision> ConsultarRevision2(string restName, CRevision revision)
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
                    string tipo = read.GetString(2);
                    CRevision rev = new CRevision();
                    rev.Id = id;
                    rev.Name = nombre;
                    rev.Tipo = tipo;
                    lista_rev.Add(rev);
                }
            }
>>>>>>> refs/remotes/origin/Develop
            CloseConnection();
            return lista_rev;
        }

        public List<CRevision> Eliminar_Revision(string usuario, CRevision revision)
        {
<<<<<<< HEAD

            string query = "SELECT rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo,rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us, Reserva_Restaurante as rest where val.rv_FK_rev=rev.rev_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + apellido + "%') and rev.rev_FK_usu_id=us.usu_id and rest.FK_USUARIO=us.usu_id and rest.ID=rev.rev_FK_res_res_id";
=======
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + usuario + "%' '%" + revision + "%')";
>>>>>>> refs/remotes/origin/Develop
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
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
                    lista_rev.Add(rev);
                }
            }
            CloseConnection();
            return lista_rev;
        }

        public List<CRevision> Crear_Revision(CReservation_Restaurant res, string usuario)   //aca iria el INSERT
        {
<<<<<<< HEAD

            string query = "SELECT rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo, rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us, Reserva_Habitacion as hot where val.rv_FK_rev=rev.rev_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + nombre + "%') and rev.rev_FK_usu_id=us.usu_id AND hot.rha_fk_usu_id=us.usu_id and hot.rha_id=rev.rev_FK_res_hot_id";
=======
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + usuario + "%' '%" + usuario + "%')";
>>>>>>> refs/remotes/origin/Develop
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
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
                    lista_rev.Add(rev);
                }
            }
            CloseConnection();
            return lista_rev;
        }

<<<<<<< HEAD
        public bool Editar_Revision(string nombre, string apellido, int revision)  // FALTA
=======

        public List<CRevision> Crear_RevisionHotel(CReservation_Restaurant res, string usuario, DateTime fecha)   //aca iria el INSERT
>>>>>>> refs/remotes/origin/Develop
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
                    string tipo = read.GetString(2);
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
        public List<CRevision> BuscarRevisiones(int id)
        {

            string query = "SELECT rest.rst_id, rest.rst_nombre, rev.rev_mensaje, rev.rev_puntuacion FROM Restaurante as rest, Reserva_Restaurante as res, Revision as rev  WHERE   rev.rev_tipo=1 and rev.rev_FK_res_res_id=res.ID and rest.rst_id=res.FK_RESTAURANTE rest.rst_id= '" + id + "'";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    int _Id = read.GetInt32(0);
                    DateTime _fecha = read.GetDateTime(1);
                    string _mensaje = read.GetString(2);
                    int _tipo = read.GetInt32(3);
                    int _puntuacion = read.GetInt32(4);

                    CRevision rev = new CRevision();
                    rev.Id = _Id;
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    lista_rev.Add(rev);
                }
                return lista_rev;
            }
            return null;
        }
    }


}




