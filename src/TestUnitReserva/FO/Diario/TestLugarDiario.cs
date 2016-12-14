<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Models.Diarios;
using FOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;

namespace TestUnitReserva.FO.Diario_Viaje
{

    //Prueba de carga de lugar
     [TestFixture]
    class TestLugarDiario
    {
        ManejadorSQLDiarios query_sql= new ManejadorSQLDiarios();
      
         [Test]
        public void TestConsultarLugares()
        {
            var listado =  query_sql.obtenerLugares();
            Assert.IsInstanceOf(typeof(List<CLugar>), listado);
            foreach (var indice in listado)
            {
                Debug.WriteLine("El Lugar es: " + indice.Nombre);
            }
        }


    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Models.Diarios;
using FOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;

namespace TestUnitReserva.FO.Diario_Viaje
{

    //Prueba de carga de lugar
     [TestFixture]
    class TestLugarDiario
    {
        ManejadorSQLDiarios query_sql= new ManejadorSQLDiarios();
      
         [Test]
        public void TestConsultarLugares()
        {
            var listado =  query_sql.obtenerLugares();
            Assert.IsInstanceOf(typeof(List<CLugar>), listado);
            foreach (var indice in listado)
            {
                Debug.WriteLine("El Lugar es: " + indice.Nombre);
            }
        }


    }
}
>>>>>>> Develop
