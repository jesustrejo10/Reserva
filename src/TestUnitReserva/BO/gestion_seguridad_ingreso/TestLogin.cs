using BOReserva.Servicio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.Models.gestion_seguridad_ingreso;

namespace TestUnitReserva.BO.gestion_seguridad_ingreso
{
    [TestFixture]
    class TestLogin
    {
        M01SQL bd = new M01SQL();

       /* [Test]
        public void ExcepcionSQL() {
            Assert.Throws<SqlException>(()=>bd.UsuarioEnBD(null));
        }*/


        //Test de que no hubieron problemas en conectarse a la bd
        //Querys que retornen null no significan que no retornan true
        //El true solo significa que no hubo probelmas en el query
        [Test]
        public void PruebaUsuarioEnBD()
        {
            Assert.IsInstanceOf<Cgestion_seguridad_ingreso>(bd.UsuarioEnBD("drbr@reserva.com"));
        }

        [Test]
        public void PruebaResetearIntentos()
        {
            Assert.IsTrue(bd.ResetearIntentos("prueba"));
        }

        [Test]
        public void PruebaIncrementarIntentos()
        {
            Assert.IsTrue(bd.IncrementarIntentos("prueba"));
        }

        [Test]
        public void PruebaBloqueoUsuario()
        {
            Assert.IsTrue(bd.BloquearUsuario("prueba"));
        }

        [Test]
        public void PruebaInsertarLogin()
        {
            Assert.IsTrue(bd.InsertarLogin("prueba"));
        }

        [Test]
        public void PruebaNumeroIntentos()
        {
            Assert.AreEqual(bd.NumeroIntentos("prueba"),0);
        }
        //Fin pruebas SQL
        [Test]
        public void PruebaTipoModelo()
        {
            Cgestion_seguridad_ingreso modelo =new Cgestion_seguridad_ingreso("prueba@Correo", 
                "pruebaClave", "pruebaNombre", "pruebaApellido", "activo");
            Assert.IsInstanceOf<Cgestion_seguridad_ingreso>(modelo);
        }

        [Test]
        public void PruebaActivo()
        {
            Cgestion_seguridad_ingreso modelo = new Cgestion_seguridad_ingreso("prueba@Correo", 
                "pruebaClave", "pruebaNombre", "pruebaApellido", "activo");
            Assert.IsTrue(modelo.EstaActivo());
        }
        //Pruebas de modelo

        //Fin de pruebas de modelo
    }
}
