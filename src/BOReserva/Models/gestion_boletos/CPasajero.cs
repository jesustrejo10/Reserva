using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_boletos
{
    public class CPasajero
    {
        public CPasajero (){
        }

        public CPasajero (int id, String nombre, String apellido, String correo){
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

        public int _id {get; set;}

        public String _primer_nombre {get; set;}

        public String _primer_apellido {get; set;}

        public String _segundo_nombre {get; set;}

        public String _segundo_apellido {get; set;}

        public String _fecha_nac {get; set;}

        public String _sexo {get; set;}

        public String _correo {get; set;}
    }
}