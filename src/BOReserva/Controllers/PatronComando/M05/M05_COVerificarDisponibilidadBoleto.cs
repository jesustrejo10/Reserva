using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;


namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para ingresar un pasajero
    /// </summary>
    public class M05_COVerificarDisponibilidadBoleto : Command<bool>
    {
        int _codigo_vuelo;
        String _tipo;

        public M05_COVerificarDisponibilidadBoleto(int codigo_vuelo, String tipo)
        {
            this._codigo_vuelo = codigo_vuelo;
            this._tipo = tipo;
        }

        public override bool ejecutar()
        {
            bool disponibilidad = false;
            IDAOBoleto daoBoleto = (IDAOBoleto)FabricaDAO.instanciarDaoBoleto();
            int conteo = daoBoleto.MConteoCategoria(_codigo_vuelo, _tipo);
            int cap = daoBoleto.MConteoCapacidad(_codigo_vuelo, _tipo);
            if (conteo < cap)
            {
                disponibilidad = true;
            }
            else
            {
                disponibilidad = false;
            }
            return disponibilidad;
        }

    }
}