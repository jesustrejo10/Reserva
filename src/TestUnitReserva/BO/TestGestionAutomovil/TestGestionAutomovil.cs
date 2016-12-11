using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;

namespace TestUnitReserva.BO.TestGestionAutomovil
{
    [TestFixture]
    public class  TestGestionAutomovil
       
    
    {
  
        [Test]
        public void prueba() {

            
            Automovil auto = new Automovil("pruba","3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            DAOAutomovil Has = new DAOAutomovil();
            int prueba1 = Has.MAgregarVehiculoBD(auto);
            Debug.WriteLine(prueba1);
            Assert.AreEqual(1, prueba1);

        }


    }
}
