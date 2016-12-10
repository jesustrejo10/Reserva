using BOReserva.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Automovil
    {
        
          public String _matricula { get; set; } 
          public String _modelo { get; set; } 
          public String _fabricante { get; set; } 
          public int _anio { get; set; } 
          public String _tipovehiculo { get; set; } 
          public double _kilometraje { get; set; } 
          public int _cantpasajeros { get; set; } 
          public double _preciocompra { get; set; } 
          public double _precioalquiler { get; set; } 
          public double _penalidaddiaria { get; set; }
          public DateTime _fecharegistro { get; set; } 
          public String _color { get; set; } 
          public int _disponibilidad { get; set; }
          public String _transmision { get; set; } 
          public String _pais { get; set; } 
          public String _ciudad { get; set; } 
        
       
          public Automovil(String matricula, String modelo, String fabricante, int anio, String tipovehiculo, double kilometraje, int cantpasajeros, 
                         double preciocompra, double precioalquiler, double penalidaddiaria, DateTime fecharegistro, String color, int disponibilidad, 
                         String transmision, String pais, String ciudad)
          {
              _matricula  = matricula;
              _modelo = modelo;
              _fabricante = fabricante;
              _anio = anio;
              _tipovehiculo = tipovehiculo;
              _kilometraje = kilometraje;
              _cantpasajeros = cantpasajeros;
              _preciocompra = preciocompra;
              _precioalquiler = precioalquiler;
              _penalidaddiaria = penalidaddiaria;
              _fecharegistro = fecharegistro;
              _color = color;
              _disponibilidad = disponibilidad;
              _transmision = transmision;
              _pais = pais;
              _ciudad = ciudad;
          }

         public int MAgregaraBD (Automovil vehiculo){ //METODO PARA AGREGAR A LA BASE DE DATOS
             DAOAutomovil agregar = new DAOAutomovil();
             return agregar.MAgregarVehiculoBD(vehiculo);
         }

         public List<Automovil> MListarvehiculos() //METODO PARA OBTENER LA LISTA DE VEHICULOS DE LA BASE DE DATOS
         {
             DAOAutomovil listar = new DAOAutomovil();
             return listar.MListarvehiculosBD();
         }

         public Automovil MConsultarvehiculo(String matricula) //METODO PARA OBTENER LOS DATOS DE UN VEHICULO EN ESPECIFICO DE LA BASE DE DATOS
         {
             DAOAutomovil consultar = new DAOAutomovil();
             return consultar.MMostrarvehiculoBD(matricula);
         }
   
         public int MDisponibilidadVehiculoBD (String matricula, int activar_o_desactivar){ //METODO PARA ACTIVAR UN VEHICULO, EN EL INT activar_o_desactivar 1 ES ACTIVAR Y 0 DESACTIVAR
             DAOAutomovil consultar = new DAOAutomovil();
             return consultar.MDisponibilidadVehiculoBD(matricula,activar_o_desactivar);
         }

         
         public int MModificarvehiculoBD(Automovil vehiculo) //METODO PARA MODIFICAR UN VEHICULO
          {
              DAOAutomovil modificar = new DAOAutomovil();
              return modificar.MModificarVehiculoBD(vehiculo);
          }

         public int MBorrarvehiculoBD(String vehiculo) //METODO PARA MODIFICAR UN VEHICULO
         {
             DAOAutomovil modificar = new DAOAutomovil();
             return modificar.MBorrarvehiculoBD(vehiculo);
         }

    }

}
