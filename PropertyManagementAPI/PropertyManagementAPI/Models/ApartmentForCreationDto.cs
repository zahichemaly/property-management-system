using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public class ApartmentForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required(ErrorMessage = "You should proved the number of rooms.")]
        public int NbOfRooms { get; set; }
    }
}
