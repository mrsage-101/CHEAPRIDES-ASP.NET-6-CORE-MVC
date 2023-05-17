using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS8618
namespace CHEAPRIDES.Models
{
    public class RideBooking
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bookingid { get; set; }

        [Required]
        public string Pickuplocation { get; set; }

        [Required]
        public string Droplocation { get; set; }

        [Required]
        public int Fare { get; set; }

        public int Carid { get; set; }

        [ForeignKey("Carid")]
        public virtual CarRegShow? CarRegShow { get; set; }
    }
}
