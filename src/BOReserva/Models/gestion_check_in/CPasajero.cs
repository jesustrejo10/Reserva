using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_check_in
{
    public class CPasajero
    {
        public CPasajero()
        {
        }

        public CPasajero(int id, String nombre, String apellido, String correo)
        {
            _id = id;
            _primer_nombre = nombre;
            _primer_apellido = apellido;
            _correo = correo;
        }

        public CPasajero(int id, String nombre, String apellido)
        {
            _id = id;
            _primer_nombre = nombre;
            _primer_apellido = apellido;
        }

        public CPasajero(int id, String nombre1, String nombre2, String apellido1, String apellido2, String sexo,
                        DateTime fecha, String correo)
        {
            _id = id;
            _primer_nombre = nombre1;
            _segundo_nombre = nombre2;
            _primer_apellido = apellido1;
            _segundo_apellido = apellido2;
            _fecha_nac = fecha;
            _sexo = sexo;
            _correo = correo;
            _fecha = fecha.Day + "/" + fecha.Month + "/" + fecha.Year;
        }

        public int _id { get; set; }

        public String _primer_nombre { get; set; }

        public String _primer_apellido { get; set; }

        public String _segundo_nombre { get; set; }

        public String _segundo_apellido { get; set; }

        public DateTime _fecha_nac { get; set; }

        public String _fecha { get; set; }

        public String _sexo { get; set; }

        public String _correo { get; set; }
    }
}