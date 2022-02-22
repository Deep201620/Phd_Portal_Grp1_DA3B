using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Phd_Portal_Grp1_DA3B.Models
{
    public class UserInfo
    {

        [Display(Name = "User Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Display(Name = "UserName")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string UserName { get; set; }


        [Display(Name = "User Email")]
        [EmailAddress]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string UserEmail { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }
      

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 characters.")]
        public string Password { get; set; }

        [RegularExpression("([0-9]+)")]
        [Display(Name = "User Phone")]
        [Required]
        public long Phone { get; set; }

        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string RoleType { get; set; }
    }
}
