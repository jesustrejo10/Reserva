using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.DataAccessObject.M14;
using System.Data;
using FOReserva.Models.Sesion;

namespace FOReserva.DataAccess.DataAccessObject.M14
{
    public class DAORegistroU : DAO, IDAORegistroU
    {

        public DAORegistroU() { }
        /// <summary>
        /// Metodo para guardar un usuario que se registra  en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Usuario</param>
        /// <returns>Integer con el codigo de respuesta</returns>
        public int AgregarUsuario(Entidad e)
        {
            Usuario1 u = (Usuario1)e;
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_nombre, SqlDbType.VarChar, u.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_apellido, SqlDbType.VarChar, u.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_correo, SqlDbType.VarChar, u.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_contraseña, SqlDbType.VarChar, Seguridad.Cifrar(u.clave), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_fechaCreacion, SqlDbType.VarChar, DateTime.Now.ToString("yyyy-MM-dd"), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_activo, SqlDbType.VarChar, "Activo", false));

                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.pregunta1, SqlDbType.Int, u.pregunta1.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.respuesta1, SqlDbType.VarChar, u.respuesta1, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.pregunta2, SqlDbType.Int, u.pregunta2.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.respuesta2, SqlDbType.VarChar, u.respuesta2, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.pregunta3, SqlDbType.Int, u.pregunta3.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.respuesta3, SqlDbType.VarChar, u.respuesta3, false));
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_AgregarRestarurante, importante ese nombre se coloco en un archivo de recursos por efectos practicos, pero se puede 
                //como String "dbo.M10_AgregarRestarurante"
                EjecutarStoredProcedure(RecursoDAOM14.procedimientoAgregar, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }
            //devuelve 1 sino existe el correo, 0 si ya existe.
            return 1;
        }


        public int VerificarCorreo(Entidad e)
        {
            //Se castea de tipo Entidad a tipo Usuario
            Usuario1 u = (Usuario1)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el correo del usuario @usu_correo (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_correo, SqlDbType.VarChar, u.correo, false));

                //Se devuelve la fila del restaurante consultado segun el correo, para este caso solo se devuelve una fila
                DataTable filarUsuario = EjecutarStoredProcedureTuplas(RecursoDAOM14.procedimientoVerificarCorreo, listaParametro);

                if (filarUsuario.Rows.Count == 0)
                {
                    return 0;
                }

                else
                {
                    return 1;

                }

            }
            catch (Exception)
            {

                throw;
            }


        }



        public int ConsultarUsuarioLogin(Entidad e)
        {
            //Se castea de tipo Entidad a tipo Usuario
            Usuario1 u = (Usuario1)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            //Atributos tabla Restaurant 
            int idUsuario;
            String nombreUsuario;
            String apellidoUsuario;
            String contraseñaUsuario;

            Entidad usuario;



            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el correo del usuario @usu_correo (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_correo, SqlDbType.VarChar, u.correo, false));

                //Se devuelve la fila del restaurante consultado segun el correo, para este caso solo se devuelve una fila
                DataTable filarUsuario = EjecutarStoredProcedureTuplas(RecursoDAOM14.procedimientoVerificarCorreo, listaParametro);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filarUsuario.Rows[0];



                //Se preinicializan los atributos de la clase usuario
                idUsuario = int.Parse(Fila[RecursoDAOM14.usuarioId].ToString());
                nombreUsuario = Fila[RecursoDAOM14.usuarioNombre].ToString();
                apellidoUsuario = Fila[RecursoDAOM14.usuarioApellido].ToString();
                contraseñaUsuario = Fila[RecursoDAOM14.usuarioContrasena].ToString();
                usuario = FabricaEntidad.InstanciarUsuario(nombreUsuario, apellidoUsuario, u.correo, contraseñaUsuario);


                //se retorna la entidad de restaurant a mostrar en la vista



                if (Seguridad.Descifrar(contraseñaUsuario) == u.clave)
                {
                    return 1;

                }

                else

                    return 0;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Entidad ConsultarUsuarioPerfil(Entidad e)
        {
            //Se castea de tipo Entidad a tipo Usuario
            Usuario1 u = (Usuario1)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            //Atributos tabla Restaurant 
            String nombreUsuario;
            String correoUsuario;
            String apellidoUsuario;
            String codAreaUsuario;
            String telefonoUsuario;
            String generoUsuario;

            Entidad usuario;



            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el correo del usuario @usu_correo (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_correo, SqlDbType.VarChar, u.correo, false));

                //Se devuelve la fila del restaurante consultado segun el correo, para este caso solo se devuelve una fila
                DataTable filarUsuario = EjecutarStoredProcedureTuplas(RecursoDAOM14.M14_BuscarUsuario, listaParametro);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filarUsuario.Rows[0];



                //Se preinicializan los atributos de la clase usuario
                nombreUsuario = Fila[RecursoDAOM14.usuarioNombre].ToString();
                apellidoUsuario = Fila[RecursoDAOM14.usuarioApellido].ToString();
                codAreaUsuario = Fila[RecursoDAOM14.usuarioCodArea].ToString();
                telefonoUsuario = Fila[RecursoDAOM14.usuarioTelefono].ToString();
                generoUsuario = Fila[RecursoDAOM14.usuarioGenero].ToString();
                usuario = FabricaEntidad.InstanciarUsuario(nombreUsuario,apellidoUsuario,u.correo, codAreaUsuario, telefonoUsuario, generoUsuario);

                return usuario;

            }
            catch (Exception)
            {

                throw;
            }


        }


        /// <summary>
        /// Metodo para modificar perfil
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Se retorna true de ser exitoso</returns>
        public bool ModificarPerfil(Entidad _cliente)
        {
            Usuario1 cliente = (Usuario1)_cliente;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_id, SqlDbType.Int, cliente.id.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_nombre, SqlDbType.VarChar, cliente.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_apellido, SqlDbType.VarChar, cliente.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_correo, SqlDbType.VarChar, cliente.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.per_genero, SqlDbType.VarChar, cliente.genero, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.tel_cod_area, SqlDbType.Int, cliente.codigo_area, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.tel_num_telefonico, SqlDbType.Int, cliente.telefono, false));

                EjecutarStoredProcedure(RecursoDAOM14.M14_ModificarPerfil, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public bool IniciarSesion(Entidad _cliente)
        {
            Usuario1 cliente = (Usuario1)_cliente;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_correo, SqlDbType.VarChar, cliente.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM14.usu_clave0, SqlDbType.VarChar, Seguridad.Cifrar(cliente.clave0), false));

                //debe asignar a una lista <ResultadoDB>
                EjecutarStoredProcedure(RecursoDAOM14.M14_IniciarSesion, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }










    }
}
