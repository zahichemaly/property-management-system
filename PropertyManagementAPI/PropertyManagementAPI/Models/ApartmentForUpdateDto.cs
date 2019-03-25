using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public class ApartmentForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        public int NbOfRooms { get; set; }
        public int Price { get; set; }
    }
}
