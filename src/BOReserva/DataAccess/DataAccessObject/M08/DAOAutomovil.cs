using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Models.gestion_automoviles;
using BOReserva.DataAccess.DataAccessObject.M08;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
            Automovil automovil = (Automovil)_automovil;
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.matricula,         SqlDbType.VarChar,  automovil.matricula,                    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.modelo,            SqlDbType.VarChar,  automovil.modelo,                       false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fabricante,        SqlDbType.VarChar,  automovil.fabricante,                   false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.anio,              SqlDbType.Int,      automovil.anio.ToString(),              false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.kilometraje,       SqlDbType.VarChar,  automovil.kilometraje.ToString(),       false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.cantpasajero,      SqlDbType.Decimal,  automovil.cantpasajeros.ToString(),     false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.tipovehiculo,      SqlDbType.Int,      automovil.tipovehiculo,                 false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.preciocompra,      SqlDbType.Decimal,  automovil.preciocompra.ToString(),      false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.precioalquiler,    SqlDbType.Decimal,  automovil.precioalquiler.ToString(),    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.penalidaddiaria,   SqlDbType.Decimal,  automovil.penalidaddiaria.ToString(),   false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fecharegistro,     SqlDbType.Date,     automovil.fecharegistro.ToString(),     false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.color,             SqlDbType.VarChar,  automovil.color,                        false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.disponibilida,     SqlDbType.Int,      automovil.disponibilidad.ToString(),    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.transmision,       SqlDbType.VarChar,  automovil.transmision,                  false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fk_ciudad,         SqlDbType.Int,      automovil.ciudad.ToString(),            false));
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_AgregarRestarurante, importante ese nombre se coloco en un archivo de recursos por efectos practicos, pero se puede 
                //como String "dbo.M10_AgregarRestarurante"
                EjecutarStoredProcedure(RecursoDAOM08.procedimientoAgregarAutomovil, listaParametro);
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

        public bool Eliminar(Entidad _automovil)
        {
            Automovil automovil = (Automovil)_automovil;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {   
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.aut_matricula, SqlDbType.Int, automovil._id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM08.procedimientoEliminarAutomovil, parametro);
            }
            catch (Exception)
            {

                throw;
            }
            return false; //se retorna falso en caso de no ser exitoso el procedimiento eliminar
        }

        public Entidad Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }
    }
}
