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
        [Required(ErrorMessage = "Car Name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Car Name must contain alphabetic characters only")]
        public string cName { get; set; }


        [Display(Name = "CarModel")]
        [Required(ErrorMessage = "Car Model is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Car Name must contain alphabetic characters only")]
        public string cModel { get; set; }

        [Display(Name = "CarMake")]
        [Required(ErrorMessage = "Car Make is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Car Make must contain numeric characters only")]
        public string cMake { get; set; }


        [Display(Name = "CarRegistrationNumber")]
        [Required(ErrorMessage = "Car Registration Number is required")]
        [RegularExpression("^[A-Z0-9-]+$", ErrorMessage = "Car Registration Number must contain uppercase letters, hyphens, and numbers only")]
        public string cRegNum { get; set; }


        [Display(Name = "PersonId")]
        public int pId { get; set; }

        [ForeignKey("pId")]
        public virtual PersonInfo? PersonInfos1 { get; set; }

        [Display(Name = "Type")]
        [ForeignKey("type")]
        public string type { get; set; }

        [Display(Name ="Avialable")]
        public bool avialability { get; set; }

        public virtual List<RideBooking>? RideBookings { get; set; }

    }
}
