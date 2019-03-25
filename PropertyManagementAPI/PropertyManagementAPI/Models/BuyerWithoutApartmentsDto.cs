using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public class BuyerWithoutApartmentsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Credits { get; set; }
        public int NbOfOwnedApartments { get; set; }
    }
}
