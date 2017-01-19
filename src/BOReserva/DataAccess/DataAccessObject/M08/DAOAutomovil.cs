using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOAutomovil : DAO, IDAOAutomovil
    {
        public int Activar(Entidad e)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Metodo para agregar automovil
        /// </summary>
        /// <param name="_automovil"></param>
        /// <returns>Se retorna true si fue exitoso</returns>
        public bool Agregar(Entidad _automovil)
        {
            CRestauranteModelo rest = (CRestauranteModelo)_restaurant;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                //Aqui se asignan los valores de cada uno de los atributos perteneciente a la tabla restaurant
                //estas linea se repite por cada una de las columnas de la tabla, e.g. se tiene el atributo nombre de tipo varchar
                //primero se obtiene por el archivo de recurso el nombre del parametro @nombre, luego el tipo de dato SQL
                // varchar, despues el valor a insertar Sabor y Sazon, finalmente el booliano para input (envio de parametro al store procedure)y output(recibir parametro del store procedure) para este caso falso 
                // la tabla restaurant contiene siete columna incluyendo la clave foranea lugar por lo cual son siete lineas de codigo
                //a;go importante de destacar es que si en la declaracion del store procedures el atributo varchar o cualquier otro
                //que requiera longitud e.g. Varchar(50) solo se inserta el primer caracter, ya que solo por defecto la longitud es 1
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_nombre, SqlDbType.VarChar, rest.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_direccion, SqlDbType.VarChar, rest.direccion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_descripcion, SqlDbType.VarChar, rest.descripcion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_hora_apertura, SqlDbType.VarChar, rest.horarioApertura, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_hora_cierre, SqlDbType.VarChar, rest.horarioCierre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_telefono, SqlDbType.VarChar, rest.Telefono, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.fk_lugar, SqlDbType.Int, rest.idLugar.ToString(), false));
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_AgregarRestarurante, importante ese nombre se coloco en un archivo de recursos por efectos practicos, pero se puede 
                //como String "dbo.M10_AgregarRestarurante"
                EjecutarStoredProcedure(RecursoDAOM10.procedimientoAgregar, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }



            return true;
        }



        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public int Desactivar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Entidad Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }
    }
}
