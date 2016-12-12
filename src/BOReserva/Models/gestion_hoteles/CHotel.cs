using BOReserva.Servicio.Servicio_Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_hoteles
{
    public class CHotel
    {
        public int _id {get; set; }
        public String _nombre { get; set; }
        public String _paginaweb { get; set; }
        public string _email { get; set; }
        public int _canthabitaciones { get; set; }
        public String _direccion { get; set; }        
        public String _ciudad { get; set; }
        public String _pais { get; set; }
        public int _estrellas { get; set; }
        public float _puntuacion { get; set; }
        public int _disponibilidad { get; set; }
        public List<SelectListItem> _listapaises { get; set;}

        public CHotel() { }

        public CHotel(int id, String nombre, String paginaweb, string email, int canthabitaciones, String direccion, String ciudad, String pais, int estrellas,
             float puntuacion, int disponibilidad)
        {
            _id = id;
            _nombre = nombre;
            _paginaweb = paginaweb;
            _email = email;
            _canthabitaciones = canthabitaciones;
            _pais = pais;
            _ciudad = ciudad;
            _direccion = direccion;
            _estrellas = estrellas;
            _puntuacion = puntuacion;
            _disponibilidad = disponibilidad;
        }

        public List<CHotel> MListarHoteles() //METODO PARA OBTENER LA LISTA DE HOTELES DE LA BASE DE DATOS
        {
            CManejadorSQL_Rutas listar = new CManejadorSQL_Rutas();
            return listar.MListarHotelesBD();
        }

    }
}