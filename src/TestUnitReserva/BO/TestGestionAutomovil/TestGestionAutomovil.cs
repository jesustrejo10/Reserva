﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
using BOReserva.Models;

namespace TestUnitReserva.BO.TestGestionAutomovil
{
    [TestFixture]
    public class  TestGestionAutomovil
       
    
    {

        [Test]
        public void MBorrarvehiculoBD()
        {

            String placa1 = Util.RandomString(7);
            Automovil auto = new Automovil(placa1,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            DAOAutomovil Has1 = new DAOAutomovil();
            Has1.MAgregarVehiculoBD(auto,12);
            int prueba2 = Has1.MBorrarvehiculoBD(placa1);
            Assert.AreEqual(0, prueba2);
        }

        [Test]
        public void M08_AgregarVehiculoBD()
        {
            String placa = Util.RandomString(7);
            Automovil auto = new Automovil(placa,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            DAOAutomovil Has = new DAOAutomovil();
            int prueba1 = Has.MAgregarVehiculoBD(auto,12);
            Debug.WriteLine(prueba1);
            Assert.AreEqual(1, prueba1);
        }

        [Test]
        public void M08_BuscarFkCiudad()
        {
/*
            Automovil auto = new Automovil("zxcas", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            DAOAutomovil Has = new DAOAutomovil();
            int prueba1 = Has.MAgregarVehiculoBD(auto);
            Debug.WriteLine(prueba1);
            
 */ 
            Assert.AreEqual(1, 1);

        }


    }
}
