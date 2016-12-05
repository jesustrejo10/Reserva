using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    public class CListRevision : List <CRevision>
    {
        private int num;





        public CListRevision(int numero) 
 
            {
    
                 this.num = numero;
                 
    }

        public CListRevision()
        {
            // TODO: Complete member initialization
        }

         

    }
}