//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOReserva.Models.ORM
{
    using System;
    
    public partial class M20_DetalleReservaHabitacion_Result
    {
        public int hot_id { get; set; }
        public string hot_nombre { get; set; }
        public int usu_id { get; set; }
        public string fullname { get; set; }
        public int rha_id { get; set; }
        public int rha_habitacion { get; set; }
        public System.DateTime rha_fecha_llegada { get; set; }
        public int rha_cantidad_dias { get; set; }
        public Nullable<System.DateTime> rha_fecha_partida { get; set; }
        public int rha_estado { get; set; }
    }
}