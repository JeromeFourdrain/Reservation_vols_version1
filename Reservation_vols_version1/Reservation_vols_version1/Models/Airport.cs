using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation_vols
{
    public class Airport
    {
        public int AirportId { get; set; }

        [Required(ErrorMessage = "Nom requis")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Adresse requise")]
        public string Address { get; set; }

        public Airport()
        {

        }

        public Airport(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
        }

        public Airport(int AirportId, string Name, string Address)
        {
            this.AirportId = AirportId;
            this.Name = Name;
            this.Address = Address;
        }

        public override string ToString()
        {
            return String.Format("Name : {0} Adresse : {1}", this.Name, this.Address);
        }
    }
}
