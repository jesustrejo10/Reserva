using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.gestion_reserva_automovil
{
    public class CLugar : Entidad
    {
        #region Atributos
        public int _id { get; set; }
        public string _nombre { get; set; }
        public string _tipoLugar { get; set; }
        public int _zonaHoraria { get; set; }
        public string _abreviatura { get; set; }
        public int _idFKLugar { get; set; }
        public List<CLugar> _listaCiudades { get; set; }
        #endregion

        #region Constructores

        /* Constructor por defecto */

        public CLugar()
        {

        }

        /* Constructor completo */

        public CLugar(int id, string nombre, string tipoLugar, int zonaHoraria, string abreviatura, int idFKLugar)
        {
            this._id = id;
            this._nombre = nombre;
            this._tipoLugar = tipoLugar;
            this._zonaHoraria= zonaHoraria;
            this._abreviatura = abreviatura;
            this._idFKLugar = idFKLugar;
        }

        /* Constructor sin FK de Lugar */

        public CLugar(int id, string nombre, string tipoLugar, int zonaHoraria, string abreviatura)
        {
            this._id = id;
            this._nombre = nombre;
            this._tipoLugar = tipoLugar;
            this._zonaHoraria = zonaHoraria;
            this._abreviatura = abreviatura;
            this._idFKLugar = -1;
        }

        public CLugar(int _id, string _nombre)
        {
            this._id = _id;
            this._nombre = _nombre;
        }

        public CLugar(string _nombre)
        {
            this._nombre = _nombre;
        }


        #endregion
    }
}