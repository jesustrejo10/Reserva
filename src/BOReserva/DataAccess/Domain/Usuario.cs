using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase para el manejo de los usuarios
    /// </summary>
    public class Usuario : Entidad
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String correo { get; set; }
        public String contrasena { get; set; }
        public String clave { get; set; }
        public int rol { get; set; }
        public Rol rolr { get; set; }
        public string fechaCreacion { get; set; }
        public DateTime fechaCreacionf { get; set; }
        public String activo { get; set; }

        public Usuario()
        {

        /// <summary>
        /// Constructor Vacio utilizado mientras se le da forma al proyecto
        /// </summary>
        public Usuario()
        {

        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="correo">Correo del usuario</param>
        /// <param name="contrasena">Contrasena del usuario para el modulo M12</param>
        /// <param name="clave">clave del usuario</param>
        /// <param name="rol">Rol del usuario</param>
        /// <param name="rolr">Rolr del usuario para el modulo M12</param>
        /// <param name="fechaCreacion">FechaCreacion del usuario</param>
        /// <param name="fechaCreacionf">FechaCreacionf del usuario</param>
        /// <param name="activo">Activo del usuario</param>
        public Usuario(int id, String nombre, String apellido, String correo, String contrasena, Rol rol, DateTime fechaCreacion, String activo)
        {
            this._id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.contrasena = contrasena;
            this.rolr = rol;
            this.fechaCreacionf = fechaCreacion;
            this.activo = activo;
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="correo">Correo del usuario</param>
        /// <param name="contrasena">Contrasena del usuario para el modulo M12</param>
        /// <param name="clave">clave del usuario</param>
        /// <param name="rol">Rol del usuario</param>
        /// <param name="rolr">Rolr del usuario para el modulo M12</param>
        /// <param name="fechaCreacion">FechaCreacion del usuario</param>
        /// <param name="fechaCreacionf">FechaCreacionf del usuario</param>
        /// <param name="activo">Activo del usuario</param>
        public Usuario(String nombre, String apellido, String correo, String contrasena, Rol rol, DateTime fechaCreacion, String activo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.contrasena = contrasena;
            this.rolr = rol;
            this.fechaCreacionf = fechaCreacion;
            this.activo = activo;
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="correo">Correo del usuario</param>
        /// <param name="contrasena">Contrasena del usuario para el modulo M12</param>
        /// <param name="clave">clave del usuario</param>
        /// <param name="rol">Rol del usuario</param>
        /// <param name="rolr">Rolr del usuario para el modulo M12</param>
        /// <param name="fechaCreacion">FechaCreacion del usuario</param>
        /// <param name="fechaCreacionf">FechaCreacionf del usuario</param>
        /// <param name="activo">Activo del usuario</param>
        public Usuario(String nombre, String apellido, String correo, Rol rol, DateTime fechaCreacion, String activo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.rolr = rol;
            this.fechaCreacionf = fechaCreacion;
            this.activo = activo;
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="correo">Correo del usuario</param>
        /// <param name="contrasena">Contrasena del usuario para el modulo M12</param>
        /// <param name="clave">clave del usuario</param>
        /// <param name="rol">Rol del usuario</param>
        /// <param name="rolr">Rolr del usuario para el modulo M12</param>
        /// <param name="fechaCreacion">FechaCreacion del usuario</param>
        /// <param name="fechaCreacionf">FechaCreacionf del usuario</param>
        /// <param name="activo">Activo del usuario</param>
        public Usuario(int id, String nombre, String apellido, String correo, String contrasena, Rol rol, String activo)
        {
            this._id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.contrasena = contrasena;
            this.rolr = rol;
            this.activo = activo;
        }

        public Usuario(String nombre, String apellido, String correo, String contrasena, int _rol, DateTime fechaCreacion, String activo)
        {
            this._id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.contrasena = contrasena;
            this.rol = _rol;
            this.activo = activo;
        }
        /// <summary>
        /// Contructor para obtener fecha
        /// </summary>
        /// <returns>
        /// Retorna una fechaCreacionf
        /// </returns>
        public String getDate()
        {
            return fechaCreacionf.ToString("dd/MM/yyyy");
        }

    }
}