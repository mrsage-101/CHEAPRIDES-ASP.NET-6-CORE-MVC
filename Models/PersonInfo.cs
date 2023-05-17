using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#pragma warning disable CS8618
namespace CHEAPRIDES.Models
{
    public class PersonInfo
    {
        [Display(Name="ID")]
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pId { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }

        [Display(Name="Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name="Password")]
        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }

        [Display(Name="Address")]
        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }

        [Display(Name="Contact")]
        [Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }

        [Display(Name="type")]
        [Required(ErrorMessage = "Type is Required")]
        public char type { get; set; }

        public virtual PersonLogin? PersonLogins { get; set; }

        public virtual List<CarRegShow>? CarRegShows { get; set; }
    }
}
