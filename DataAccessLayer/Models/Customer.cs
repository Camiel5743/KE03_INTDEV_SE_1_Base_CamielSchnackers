using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Achternaam { get; set; }

        public string Land { get; set; }

        public string Postcode { get; set; }

        public string Straatnaam { get; set; }

        public string Huisnummer { get; set; }
        public bool Active { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}