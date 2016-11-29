using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }

        public Vehicle(int id, String name, String address, String town) {
            ID = id;
            Name = name;
            Address = address;
            Town = town;
        }


    }
}