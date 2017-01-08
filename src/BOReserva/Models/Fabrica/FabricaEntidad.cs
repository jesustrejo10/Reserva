using BOReserva.Models.gestion_restaurantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.Fabrica
{
    public static class FabricaEntidad
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10
        public static CRestauranteModelo inicializarRestaurant(string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo inicializarRestaurant(int id, string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(id, nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo inicializarRestaurant()
        {
            return new CRestauranteModelo();
        }

        public static Lugar inicializarLugar(int idLugar, string nombreLugar)
        {
            return new Lugar(idLugar, nombreLugar);
        }



        #endregion

        #region Modulo 11
        #endregion

        #region Modulo 12
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        #endregion

        #region Global

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }
        #endregion

    }
}