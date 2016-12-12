using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_lugares
{
    public class CLugarModelo
    {
        public int _id { get; set; }
        public int _idFKLugar { get; set; }
        public string _nombre { get; set; }
        public string _tipoLugar { get; set; }
        public int _zonaHoraria { get; set; }
        public string _abreviatura { get; set; }

        /* Constructor por defecto */

        public CLugarModelo()
        {

        }

        /* Constructor completo */

        public CLugarModelo(int id, string nombre, string tipoLugar, int zonaHoraria, string abreviatura, int idFKLugar)
        {
            this._id = id;
            this._nombre = nombre;
            this._tipoLugar = tipoLugar;
            this._zonaHoraria = zonaHoraria;
            this._abreviatura = abreviatura;
            this._idFKLugar = idFKLugar;
        }

        /* Constructor sin FK de Lugar */

        public CLugarModelo(int id, string nombre, string tipoLugar, int zonaHoraria, string abreviatura)
        {
            this._id = id;
            this._nombre = nombre;
            this._tipoLugar = tipoLugar;
            this._zonaHoraria = zonaHoraria;
            this._abreviatura = abreviatura;
            this._idFKLugar = -1;
        }
    }
}