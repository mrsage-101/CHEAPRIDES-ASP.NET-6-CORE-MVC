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

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Username can only contain letters, numbers, and underscores")]
        public string Username { get; set; }

        [Display(Name="Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string Password { get; set; }

        [Display(Name="Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact must be a 10-digit number")]
        public string Contact { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is required")]
        [RegularExpression("^[ARC]$", ErrorMessage = "Type must be either A, R, or C")]
        public string type { get; set; }


        public virtual PersonLogin? PersonLogins { get; set; }

        public virtual List<CarRegShow>? CarRegShows { get; set; }
    }
}
