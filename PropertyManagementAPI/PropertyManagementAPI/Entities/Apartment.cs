using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Entities
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public int NbOfRooms { get; set; }

        public int Price { get; set; }

        [ForeignKey("BuyerId")]
        // Foreign Key can be Null (NOT OWNED YET)
        public int? BuyerId { get; set; }
    }
}
