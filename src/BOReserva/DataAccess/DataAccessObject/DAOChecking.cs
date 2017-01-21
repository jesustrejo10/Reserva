using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOChecking : DAO, IDAOCheckIn
    {
        public List<Entidad> ListarPasesPasajero(int pasaporte)
        {
            List<Entidad> listaboletos = new List<Entidad>();
            IDAOLugar c = (DAOLugar) FabricaDAO.instanciarDaoLugar();

            try
            {
                SqlConnection con = Connection.getInstance(_connexionString);
                con.Open();
                String sql = "SELECT P.pas_id AS numpas, P.pas_fk_lugar_origen AS origen, P.pas_fk_lugar_destino AS destino, P.pas_fk_vuelo AS vuelo" +
                             " FROM Pase_Abordaje P, Boleto B " +
                             " WHERE B.bol_fk_pasajero = " + pasaporte +
                             " AND P.pas_fk_boleto = B.bol_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BoardingPass boleto = new BoardingPass(Int32.Parse(reader["numpas"].ToString()),
                                               c.ciudad(Int32.Parse(reader["origen"].ToString())),
                                               c.ciudad(Int32.Parse(reader["destino"].ToString())),
                                               Int32.Parse(reader["vuelo"].ToString()));
                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                con.Close();
                return listaboletos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}