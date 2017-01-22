using BOReserva.Servicio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Models.gestion_usuarios;
using System.Data.SqlClient;


namespace TestUnitReserva.BO.gestion_seguridad_ingreso
{/*
    [TestFixture]
    class TestLogin
    {
        //M01SQL bd;
        //Cgestion_seguridad_ingreso modelo;
        

        //[SetUp]
        //public void TestSetUp()
        //{
        //     bd = new M01SQL();
        //     modelo = new Cgestion_seguridad_ingreso("prueba@reserva.com",
        //        "12345", "pruebaNombre", "pruebaApellido", "activo");
        //}


        //[Test]
        //public void ExcepcionSQL()
        //{
        //    Assert.Throws<SqlException>(() => bd.UsuarioEnBD(null));
        //}



        ////Test de que no hubieron problemas en conectarse a la bd
        ////Querys que retornen null no significan que no retornan true
        ////El true solo significa que no hubo probelmas en el query
        //[Test]
        //public void PruebaUsuarioEnBD()
        //{
        //    var usuario = bd.UsuarioEnBD("drbr@reserva.com");
        //    Assert.IsInstanceOf(typeof(Cgestion_seguridad_ingreso), usuario);
        //    Assert.IsNotNull(usuario.correoCampoTexto);
        //    Assert.That(usuario.correoCampoTexto, Is.EqualTo("drbr@reserva.com"));
            
        //}

        //[Test]
        //public void PruebaResetearIntentos()
        //{    
        //    Assert.IsTrue(bd.ResetearIntentos("drbr@reserva.com"));    
        //}

        //[Test]       
        //public void PruebaIncrementarIntentos()
        //{
        //    Assert.IsTrue(bd.IncrementarIntentos("drbr@reserva.com"));            
        //}

        //[Test]
        //public void PruebaBloqueoUsuario()
        //{

        //    Assert.IsTrue(bd.BloquearUsuario("drbr@reserva.com"));
        //}

        //[Test]
        //public void PruebaInsertarLogin()
        //{
        //    Boolean insertar = bd.InsertarLogin("prueba@reserva.com");
        //    if (!insertar)
        //    {
        //        bd.EliminarLogin("prueba@reserva.com");
        //        Assert.IsTrue(bd.InsertarLogin("prueba@reserva.com"));
        //    }
        //    else
        //    {
        //        Assert.IsTrue(insertar);
        //    }
      
        //}

        

        //[Test]
        //public void PruebaNumeroIntentos()
        //{
        //    bd.ResetearIntentos("drbr@reserva.com");
        //    Assert.AreEqual(bd.NumeroIntentos("drbr@reserva.com"),0);
        //}
        ////Fin pruebas SQL

        ////Pruebas de modelo

        //[Test]
        //public void PruebaTipoModelo()
        //{
            
        //    Assert.IsInstanceOf<Cgestion_seguridad_ingreso>(modelo);
        //    Assert.IsNotNull(modelo);
            
        //}

        //[Test]
        //public void PruebaActivo()
        //{
            
        //    Assert.IsTrue(modelo.EstaActivo());
        //    Assert.IsNotNull(modelo);
        //}
        

        ////Fin de pruebas de modelo

        //[TearDown]
        //public void TestTearDown()
        //{
        //    bd = null;
        //    modelo = null;
        //}
        
    }
*/
}
