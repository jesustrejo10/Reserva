using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    /// <summary>
    /// Clase Lista Revision
    /// </summary>
    public class CListRevision : List<CRevision>
    {
        private int _num;
        private string _lugar;
        private CRevision _revision;

        /// <summary>
        /// Builder Lista Revision
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="lugar"></param>
        /// <param name="revision"></param>
        public CListRevision(int numero, string lugar, CRevision revision)
        {
            this._num = numero;
            this._lugar = lugar;
            this._revision = revision;
        }

        /// <summary>
        /// Builder Lista Revision Vacio
        /// </summary>
        public CListRevision()
        {

        }

        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }
        public string Lugar
        {
            get { return _lugar; }
            set { _lugar = value; }
        }
    }
}