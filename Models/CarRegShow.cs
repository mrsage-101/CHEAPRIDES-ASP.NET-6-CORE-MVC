using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


#pragma warning disable CS8618
namespace CHEAPRIDES.Models
{
    public class CarRegShow
    {
        [Display(Name="Carid")]
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Carid { get; set; }

        [Display(Name = "CarName")]
        [Required]
        public string cName { get; set; }

        [Display(Name = "CarModel")]
        [Required]
        public string cModel { get; set; }

        [Display(Name = "CarMake")]
        [Required]
        public string cMake { get; set; }

        [Display(Name = "CarRegistrationNumber")]
        [Required]
        public string cRegNum { get; set; }

        [Display(Name = "PersonId")]
        public int pId { get; set; }

        [ForeignKey("pId")]
        public virtual PersonInfo? PersonInfos1 { get; set; }

        [Display(Name = "Type")]
        [ForeignKey("type")]
        public char type { get; set; }

        [Display(Name ="Avialable")]
        public bool avialability { get; set; }

        public virtual List<RideBooking>? RideBookings { get; set; }
    }
}
