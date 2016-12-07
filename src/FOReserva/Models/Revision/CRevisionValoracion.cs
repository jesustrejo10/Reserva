using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    public class CRevisionValoracion
    {
        private int positivo;
        private int negativo;

       


         public CRevisionValoracion(int positivo, int negativo)
         {

             this.positivo = positivo;
             this.negativo = negativo;

         }
         public CRevisionValoracion() { }

         public int Positivo
         {
             get { return positivo; }
             set { positivo = value; }
         }
         public int Negativo
         {
             get { return negativo; }
             set { negativo = value; }
         }

        


    }
}