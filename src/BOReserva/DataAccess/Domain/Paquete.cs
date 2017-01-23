using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Paquete que hereda de la clase Entidad
    /// </summary>

    public class Paquete : Entidad
    {
        public int _idPaquete { get; set; }
        //Declara una propiedad _nombrePaquete de tipo String
        public String _nombrePaquete { get; set; }

        //Declara una propiedad _precioPaquete de tipo float
        public float _precioPaquete { get; set; }

        //Declara una propiedad _idAuto de tipo String
        public String _idAuto { get; set; }

        //Declara una propiedad _idRestaurante de tipo int
        public int? _idRestaurante { get; set; }

        //Declara una propiedad id_Hotel de tipo int
        public int? _idHotel { get; set; }

        //Declara una propiedad _idCrucero de tipo int
        public int? _idCrucero { get; set; }

        //Declara una propiedad _idVuelo de tipo int
        public int? _idVuelo { get; set; }

        //Declara una propiedad _fechaIniAuto de tipo DateTime
        public DateTime? _fechaIniAuto { get; set; }

        //Declara una propiedad _fechaIniRest (restaurante) de tipo DateTime
        public DateTime? _fechaIniRest { get; set; }

        //Declara una propiedad _fechaIniHotel de tipo DateTime
        public DateTime? _fechaIniHotel { get; set; }

        //Declara una propiedad _fechaIniCruc (crucero) de tipo DateTime
        public DateTime? _fechaIniCruc { get; set; }

        //Declara una propiedad _fechaIniVuelo de tipo DateTime
        public DateTime? _fechaIniVuelo { get; set; }

        //Declara una propiedad _fechaFinAuto de tipo DateTime
        public DateTime? _fechaFinAuto { get; set; }

        //Declara una propiedad _fechaFinRest de tipo DateTime
        public DateTime? _fechaFinRest { get; set; }

        //Declara una propiedad  _fechaFinHotelde tipo DateTime
        public DateTime? _fechaFinHotel { get; set; }

        //Declara una propiedad _fechaFinCruc de tipo DateTime
        public DateTime? _fechaFinCruc { get; set; }

        //Declara una propiedad _fechaFinVuelo de tipo DateTime
        public DateTime? _fechaFinVuelo { get; set; }

        // Declara una propiedad _estadoPaquete de tipo bool 
        //_estadoPaquete nos indica si el paquete está activo o no
        public bool _estadoPaquete { get; set; } 

        //Constructor de Paquete
       public Paquete (int idpaquete, String nombrepaquete, float preciopaquete, String idauto, int? idrestaurante,
                       int? idhotel, int? idcrucero, int? idvuelo, DateTime? fechainiauto, DateTime? fechainirest,
                       DateTime? fechainihotel, DateTime? fechainicruc, DateTime? fechainivuelo, 
                       DateTime? fechafinauto, DateTime? fechafinrest, DateTime? fechafinhotel, 
                       DateTime? fechafincruc, DateTime? fechafinvuelo, bool estadoPaquete)
        {

            this._id = idpaquete;
            this._precioPaquete = preciopaquete;
            this._nombrePaquete = nombrepaquete;
            this._idAuto = idauto;
            this._idRestaurante = idrestaurante;
            this._idHotel = idhotel;
            this._idCrucero = idcrucero;
            this._idVuelo = idvuelo;
            this._fechaIniAuto = fechainiauto;
            this._fechaIniRest = fechainirest;
            this._fechaIniHotel = fechainihotel;
            this._fechaIniCruc = fechainicruc;
            this._fechaIniVuelo = fechainivuelo;
            this._fechaFinAuto = fechafinauto;
            this._fechaFinRest = fechainirest;
            this._fechaFinHotel = fechafinhotel;
            this._fechaFinCruc = fechafincruc;
            this._fechaFinVuelo = fechafinvuelo;
            this._estadoPaquete = estadoPaquete;
           
        }

       //Constructor de Paquete
       public Paquete(String nombrepaquete, float preciopaquete, String idauto, int? idrestaurante,
                       int? idhotel, int? idcrucero, int? idvuelo, DateTime? fechainiauto, DateTime? fechainirest,
                       DateTime? fechainihotel, DateTime? fechainicruc, DateTime? fechainivuelo,
                       DateTime? fechafinauto, DateTime? fechafinrest, DateTime? fechafinhotel,
                       DateTime? fechafincruc, DateTime? fechafinvuelo, bool estadoPaquete)
       {

           this._nombrePaquete = nombrepaquete;
           this._precioPaquete = preciopaquete;
           this._idAuto = idauto;
           this._idRestaurante = idrestaurante;
           this._idHotel = idhotel;
           this._idCrucero = idcrucero;
           this._idVuelo = idvuelo;
           this._fechaIniAuto = fechainiauto;
           this._fechaIniRest = fechainirest;
           this._fechaIniHotel = fechainihotel;
           this._fechaIniCruc = fechainicruc;
           this._fechaIniVuelo = fechainivuelo;
           this._fechaFinAuto = fechafinauto;
           this._fechaFinRest = fechainirest;
           this._fechaFinHotel = fechafinhotel;
           this._fechaFinCruc = fechafincruc;
           this._fechaFinVuelo = fechafinvuelo;
           this._estadoPaquete = estadoPaquete;

       }

       //Constructor de Paquete
       public Paquete(int idpaquete, String nombrepaquete, float preciopaquete, bool estadoPaquete)
       {
           this._idPaquete = idpaquete;
           this._nombrePaquete = nombrepaquete;
           this._precioPaquete = preciopaquete;
           this._estadoPaquete = estadoPaquete;

       }
    }
}