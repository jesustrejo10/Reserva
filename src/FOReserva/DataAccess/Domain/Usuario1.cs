using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase entidad, utilizada para poder acceder a todas las clases del DAO
    /// </summary>
    public class Usuario1 : Entidad
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String correo { get; set; }
        public String clave { get; set; }
        public String codigo_area { get; set; }
        public String genero { get; set; }
        public String telefono { get; set; }
        public String fechaCreacion { get; set; }
        public String clave0 { get; set; }
        public String clave1 { get; set; }
        public String estado { get; set; }

        public int pregunta1 { get; set; }
        public int pregunta2 { get; set; }
        public int pregunta3 { get; set; }

        public String respuesta1 { get; set; }
        public String respuesta2 { get; set; }
        public String respuesta3 { get; set; }

        public Usuario1()
        {

        }

        public Usuario1(String nombre, String apellido, String correo, String clave, int pregunta1, String respuesta1, int pregunta2, String respuesta2, int pregunta3, String respuesta3)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.clave = clave;
            this.pregunta1 = pregunta1;
            this.respuesta1 = respuesta1;
            this.pregunta2 = pregunta2;
            this.respuesta2 = respuesta2;
            this.pregunta3 = pregunta3;
            this.respuesta3 = respuesta3;


        }

        public Usuario1(String nombre, String apellido, String correo, String clave)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.clave = clave;
        }

        //constructor para iniciar sesion y editar perfil
        public Usuario1(int id, String nombre, String apellido, String codigo_area, String telefono, String genero, String correo, String clave)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.codigo_area = codigo_area;
            this.telefono = telefono;
            this.genero = genero;
            this.correo = correo;
            this.clave0 = clave;
        }

        public Usuario1(String nombre, String apellido, String correo, String codigo_area, String telefono,  String genero)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.codigo_area = codigo_area;
            this.telefono = telefono;
            this.correo = correo;
            this.genero = genero;
        }

    }
}