using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models
{
    public class Lugar: Entidad
    {
        #region Atributos
        private int _id;
        private string _nombre;
        private string _tipoLugar;
        private int _zonaHoraria;
        private string _abreviatura;
        private int _idFKLugar;
        private List<Lugar> _listaCiudades;
        #endregion

        #region Constructores

        /* Constructor por defecto */

        public Lugar()
        {

        }

        /* Constructor completo */

        public Lugar(int id, string nombre, string tipoLugar, int zonaHoraria, string abreviatura, int idFKLugar)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.TipoLugar = tipoLugar;
            this.ZonaHoraria = zonaHoraria;
            this.Abreviatura = abreviatura;
            this.IdFKLugar = idFKLugar;
        }

        /* Constructor sin FK de Lugar */

        public Lugar(int id, string nombre, string tipoLugar, int zonaHoraria, string abreviatura)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.TipoLugar = tipoLugar;
            this.ZonaHoraria = zonaHoraria;
            this.Abreviatura = abreviatura;
            this.IdFKLugar = -1;
        }

        public Lugar(int _id, string _nombre)
        {
            this.Id = _id;
            this._nombre = _nombre;
        }


        #endregion

        #region get y set
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int IdFKLugar
        {
            get
            {
                return _idFKLugar;
            }

            set
            {
                _idFKLugar = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string TipoLugar
        {
            get
            {
                return _tipoLugar;
            }

            set
            {
                _tipoLugar = value;
            }
        }

        public int ZonaHoraria
        {
            get
            {
                return _zonaHoraria;
            }

            set
            {
                _zonaHoraria = value;
            }
        }

        public string Abreviatura
        {
            get
            {
                return _abreviatura;
            }

            set
            {
                _abreviatura = value;
            }
        }

        public List<Lugar> ListaCiudades
        {
            get
            {
                return _listaCiudades;
            }

            set
            {
                _listaCiudades = value;
            }
        }

        #endregion
    }
}