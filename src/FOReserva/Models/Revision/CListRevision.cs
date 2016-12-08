using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    public class CListRevision : List <CRevision>
    {
        private int _num;
        private string _lugar;
        private CRevision _revision;






        public CListRevision(int numero, string lugar , CRevision revision)   // preguntar si coloco los atributos de CRevision
 
            {
    
            this._num = numero;
            this._lugar = lugar;
            this._revision = new CRevision();   // colocaria los atributos de la clase

                 
    }
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