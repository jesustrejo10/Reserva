using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Servicio.Servicio_Boletos;

namespace BOReserva.Models.gestion_boletos
{
    public class CBoleto
    {
          public int _id { get; set; }
 
          public int _ida_vuelta { get; set; } 

          public int _escala { get; set; } 

          public double _costo { get; set; }

          public CLugar _origen { get; set; }

          public CLugar _destino { get; set; } 
        
          public CPasajero _pasajero { get; set; } 

          public DateTime _fechaBoleto { get; set; }

          public List<CVuelo> vuelos { get; set; } 
       
          public CBoleto(int id, int ida_vuelta, int escala, double costo, String origen, String destino, 
                        String nombre, String apellido, DateTime fechaBoleto,int idPasajero, string idOrigen, string idDestino)
          {
              _id  = id;
              _ida_vuelta = ida_vuelta;
              _escala = escala;
              _costo = costo;
              _pasajero = new CPasajero ( idPasajero, nombre, apellido );
              _origen = new CLugar ( idOrigen, origen );
              _destino = new CLugar(idDestino, destino);
              _fechaBoleto = fechaBoleto;

          }

         //METODO PARA AGREGAR A LA BASE DE DATOS
         public int M05Agregar (CBoleto boleto){
             manejadorSQL_Boletos agregar = new manejadorSQL_Boletos();
             return agregar.M05AgregarBoletoBD(boleto);
         }

         //METODO PARA OBTENER LA LISTA DE BOLETOS DE LA BASE DE DATOS
         public List<CBoleto> M05ListarBoletos () 
         {
             manejadorSQL_Boletos listar = new manejadorSQL_Boletos();
             return listar.M05ListarBoletosBD();
         }

         //METODO PARA OBTENER LOS DATOS DE UN BOLETO EN ESPECIFICO DE LA BASE DE DATOS
         public CBoleto M05Consultar (int id) 
         {
             manejadorSQL_Boletos consultar = new manejadorSQL_Boletos();
             return consultar.M05MostrarBoletoBD(id);
         }

         //METODO PARA MODIFICAR UN BOLETO
         public int M05Modificar (CBoleto boleto) 
         {
              manejadorSQL_Boletos modificar = new manejadorSQL_Boletos();
              return modificar.M05ModificarBoletoBD(boleto);
         }

         //METODO PARA ELIMINAR UN BOLETO
         public int M05Eliminar(int id)
         {
             manejadorSQL_Boletos eliminar = new manejadorSQL_Boletos();
             return eliminar.M05EliminarBoletoBD(id);
         }
    }
}