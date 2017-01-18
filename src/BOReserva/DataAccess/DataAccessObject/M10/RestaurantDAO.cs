using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.M10;
using BOReserva.DataAccess.Domain;
using BOReserva.Models;
using BOReserva.Models.gestion_restaurantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BOReserva.M10
{
    public class RestaurantDAO : DAO, IDAORestaurant
    {

        /// <summary>
        /// Metodo para consultar restaurant segun el id de Lugar
        /// </summary>
        /// <param name="_restaurant">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>
        public List<Entidad> Consultar(Entidad _lugar)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeRestaurant = FabricaEntidad.asignarListaDeEntidades();
            DataTable tablaDeDatos;
            Entidad restaurant;
            Lugar lugar = (Lugar)_lugar; //Se castea a tipo Lugar para poder utilizar sus metodos 

            //Atributos tabla Restaurant 
            int idRestaurant;
            String nombreRestaurant;
            String descripcionRestaurant;
            String direccionRestaurant;
            String telefonoRestaurant;
            String horaIni;
            String horaFin;
            String nombreLugar;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID de Lugar @lug_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.lug_id, SqlDbType.Int, lugar.Id.ToString(), true, false));

                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_ConsultarRestarurante
                tablaDeDatos = EjecutarStoredProcedure(parametro, RecursoDAOM10.procedimientoConsultar);

                foreach (DataRow filarestaurant in tablaDeDatos.Rows)
                {
                    idRestaurant = int.Parse(filarestaurant[RecursoDAOM10.restaurantId].ToString());
                    nombreRestaurant = filarestaurant[RecursoDAOM10.restaurantNombre].ToString();
                    descripcionRestaurant = filarestaurant[RecursoDAOM10.restaurantDescripcion].ToString();
                    direccionRestaurant = filarestaurant[RecursoDAOM10.restaurantDireccion].ToString();
                    telefonoRestaurant = filarestaurant[RecursoDAOM10.restaurantTelefono].ToString();
                    horaIni = filarestaurant[RecursoDAOM10.restaurantHoraApertura].ToString();
                    horaFin = filarestaurant[RecursoDAOM10.restaurantHoraCierra].ToString();
                    nombreLugar = filarestaurant[RecursoDAOM10.LugarNombre].ToString();
                    restaurant = FabricaEntidad.inicializarRestaurant(idRestaurant, nombreRestaurant, direccionRestaurant, telefonoRestaurant, descripcionRestaurant, horaIni, horaFin, 0);
                    listaDeRestaurant.Add(restaurant);
                }

                return listaDeRestaurant;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo que retorna restauran segun el id
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Entidad</returns>
        public Entidad consultarRestaurantId(Entidad _restaurant)
        {
           //Se castea de tipo Entidad a tipo Restaurant
            CRestauranteModelo rest = (CRestauranteModelo)_restaurant;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            //Atributos tabla Restaurant 
            int idRestaurant;
            String nombreRestaurant;
            String descripcionRestaurant;
            String direccionRestaurant;
            String telefonoRestaurant;
            String horaIni;
            String horaFin;
            String idLugar;
            Entidad restaurant;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID del restaurante @rst_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_id, SqlDbType.Int, rest._id.ToString(), true, false));

                //Se devuelve la fila del restaurante consultado segun el Id, para este caso solo se devuelve una fila
                DataTable filarestaurant = EjecutarStoredProcedure(listaParametro, RecursoDAOM10.procedimientoConsultarRestaurantId);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filarestaurant.Rows[0];

                //Se preinicializan los atrubutos de la clase restaurant 
                idRestaurant = int.Parse(Fila[RecursoDAOM10.restaurantId].ToString());
                nombreRestaurant = Fila[RecursoDAOM10.restaurantNombre].ToString();
                descripcionRestaurant = Fila[RecursoDAOM10.restaurantDescripcion].ToString();
                direccionRestaurant = Fila[RecursoDAOM10.restaurantDireccion].ToString();
                telefonoRestaurant = Fila[RecursoDAOM10.restaurantTelefono].ToString();
                horaIni = Fila[RecursoDAOM10.restaurantHoraApertura].ToString();
                horaFin = Fila[RecursoDAOM10.restaurantHoraCierra].ToString();
                idLugar = Fila[RecursoDAOM10.LugarIdFk].ToString();
                restaurant = FabricaEntidad.inicializarRestaurant(idRestaurant, nombreRestaurant, direccionRestaurant, telefonoRestaurant, descripcionRestaurant, horaIni, horaFin, int.Parse(idLugar));

                return restaurant;
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Metodo para agregar restaurant
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Se retorna true si fue exitoso</returns>
        public bool Crear(Entidad _restaurant)
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_nombre, SqlDbType.VarChar, rest.nombre, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_direccion, SqlDbType.VarChar, rest.direccion, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_descripcion, SqlDbType.VarChar, rest.descripcion, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_hora_apertura, SqlDbType.VarChar, rest.horarioApertura, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_hora_cierre, SqlDbType.VarChar, rest.horarioCierre, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_telefono, SqlDbType.VarChar, rest.Telefono, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.fk_lugar, SqlDbType.Int, rest.idLugar.ToString(), false, false));
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_AgregarRestarurante, importante ese nombre se coloco en un archivo de recursos por efectos practicos, pero se puede 
                //como String "dbo.M10_AgregarRestarurante"
                EjecutarStoredProcedure(RecursoDAOM10.procedimientoAgregar, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }


            System.Diagnostics.Debug.WriteLine(rest.nombre);

            return true;
        }

        /// <summary>
        /// Metodo para eliminar restaurante 
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Retorna true si fue exitso</returns>
        public bool Eliminar(Entidad _restaurant)
        {
            CRestauranteModelo rest = (CRestauranteModelo)_restaurant;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {   //Aqui se asignan los valores que recibe el procedimieto para realizar el delete, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID del restaurante @rst_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_id, SqlDbType.Int, rest._id.ToString(), true, false));
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_EliminarrRestarurante, importante ese nombre se coloco en un archivo de recursos por efectos practicos, pero se puede 
                //como String "dbo.M10_EliminarRestarurante"
                EjecutarStoredProcedure(RecursoDAOM10.procedimientoEliminar, parametro);
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        /// <summary>
        /// Metodo para retornar lista de Lugares
        /// </summary>
        /// <returns>Se retorna una lista de entidad que luego debe ser casteada a su respectiva clase en el Modelo</returns>
        public List<Entidad> ListarLugar()
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeLugares = FabricaEntidad.asignarListaDeEntidades();
            Entidad lugar;
            DataTable tablaDeDatos;
            int idLugar;
            String nombreLugar;

            try
            {
                tablaDeDatos = EjecutarStoredProcedure(parametro, RecursoDAOM10.procedimientoConsultarLugar);
                listaDeLugares.Add(FabricaEntidad.inicializarLugar(0, ""));

                foreach (DataRow filaLugar in tablaDeDatos.Rows)
                {
                    idLugar = int.Parse(filaLugar[RecursoDAOM10.LugarId].ToString());
                    nombreLugar = filaLugar[RecursoDAOM10.LugarNombre].ToString();
                    lugar = FabricaEntidad.inicializarLugar(idLugar, nombreLugar);
                    listaDeLugares.Add(lugar);
                }

                return listaDeLugares;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo para modificar restaurant
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Se retorna true de ser exitoso</returns>
        public bool Modificar(Entidad _restaurant)
        {
            CRestauranteModelo rest = (CRestauranteModelo)_restaurant;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el update, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID del restaurante @rst_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_id, SqlDbType.Int, rest._id.ToString(), true, false));
                //Aqui se asignan los valores de cada uno de los atributos perteneciente a la tabla restaurant
                //estas linea se repite por cada una de las columnas de la tabla, e.g. se tiene el atributo nombre de tipo varchar
                //primero se obtiene por el archivo de recurso el nombre del parametro @nombre, luego el tipo de dato SQL
                // varchar, despues el valor a modificar Sabor y Sazon, finalmente el booliano para input (envio de parametro al store procedure)y output(recibir parametro del store procedure) para este caso falso 
                // la tabla restaurant contiene siete columna incluyendo la clave foranea lugar por lo cual son siete lineas de codigo
                //a;go importante de destacar es que si en la declaracion del store procedures el atributo varchar o cualquier otro
                //que requiera longitud e.g. Varchar(50) solo se inserta el primer caracter, ya que solo por defecto la longitud es 1
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_nombre, SqlDbType.VarChar, rest.nombre, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_direccion, SqlDbType.VarChar, rest.direccion, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_descripcion, SqlDbType.VarChar, rest.descripcion, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_hora_apertura, SqlDbType.VarChar, rest.horarioApertura, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_hora_cierre, SqlDbType.VarChar, rest.horarioCierre, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_telefono, SqlDbType.VarChar, rest.Telefono, false, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.fk_lugar, SqlDbType.Int, rest.idLugar.ToString(), false, false));
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_ActualizarRestaruranteimportante ese nombre se coloco en un archivo de recursos por efectos practicos, pero se puede 
                //como String "dbo.M10_ActualizarrRestarurante"
                EjecutarStoredProcedure(RecursoDAOM10.procedimientoActualizar, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
    }
}