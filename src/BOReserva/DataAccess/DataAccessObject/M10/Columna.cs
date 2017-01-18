using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10
{
    /// <summary>
    /// clase que permite preinicializar las columnas provenientes de la base de datos
    /// para luego crear el objeto al que le corresponda 
    /// </summary>
    public class Columna
    {
        #region Atributos
        private String _atributo;
        private String _valorAtributo;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="_atributo"></param>
        /// <param name="_valorAtributo"></param>
        public Columna(string _atributo, string _valorAtributo)
        {
            this._atributo = _atributo;
            this._valorAtributo = _valorAtributo;
        }
        #endregion

        #region Get y Set
        public string Atributo
        {
            get
            {
                return _atributo;
            }

            set
            {
                _atributo = value;
            }
        }

        public string ValorAtributo
        {
            get
            {
                return _valorAtributo;
            }

            set
            {
                _valorAtributo = value;
            }
        }

        #endregion
    }
}