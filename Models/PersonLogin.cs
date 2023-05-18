using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618
namespace CHEAPRIDES.Models
{
    public class PersonLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("type")]
        public string type { get; set; }


        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pId { get; set; }

        [ForeignKey("pId")]
        public virtual PersonInfo PersonInfo { get; set; }
    }
}
