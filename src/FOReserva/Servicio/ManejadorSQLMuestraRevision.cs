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
                    string tipo = read.GetString(2);
                    CRevision rev = new CRevision();
                    rev.Id = id;
                    rev.Name = nombre;
                    rev.Tipo = tipo;
                    lista_rev.Add(rev);
                }
            }
            CloseConextion();
            return lista_rev;
        }

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
            CloseConextion();
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
            CloseConextion();
            return lista_rev;
        }

        public List<CRevision> Crear_Revision(CReservation_Restaurant res, string usuario)   //aca iria el INSERT
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where LOWER(nom colum a bscar) LIKE LOWER('%" + usuario + "%' '%" + usuario + "%')";
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
            CloseConextion();
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
            CloseConextion();
            return lista_rev;
        }


    }


}




