using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int NbOfRooms { get; set; }
        public int? BuyerId { get; set; }
    }
}
