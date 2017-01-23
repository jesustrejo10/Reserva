using System;
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



     //Agregar un diario Sin Foto

     [TestFixture]
     class TestAviones
     {
         ManejadorSQLDiarios test = new ManejadorSQLDiarios();

         /*
            [Test]
            public void CrearDiario()
            {
                CDiarioModel diario = new CDiarioModel();
                diario.Nombre=("Titulo del Diario de Prueba 1");
                diario.Fecha_ini= Convert.ToDateTime("12/10/2016");
                diario.Descripcion=("Descripcion de la prueba 1");
                diario.Fecha_carga=DateTime.Today;
                diario.Calif_creador=4;
                diario.Rating=1;
                diario.Num_visita=1;
                diario.Usuario=11;
                diario.Fecha_fin=Convert.ToDateTime("19/10/2016");
                diario.Destino=24;
        

                //Realizando la comprobacion del valor de retorno

                int crearnuevodiario =test.CrearDiario(diario);
                Assert.AreEqual(crearnuevodiario, 0);
            
                int nocrearnuevoavion = test.CrearDiario(null);
                Assert.AreEqual(nocrearnuevoavion, 1);  
          
            }
        }

         */
     }
 }
