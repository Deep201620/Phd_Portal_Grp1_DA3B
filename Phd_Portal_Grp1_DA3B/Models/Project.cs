using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Phd_Portal_Grp1_DA3B.Models
{
    public class Project
    {
        [Display(Name = "Project Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [Display(Name = "Project Title")]
        [Required(ErrorMessage = "Project Ttile cannot be empty")]
        public string ProjectTitle { get; set; }

        [Display(Name = "Project Description")]
        [Required(ErrorMessage = "Project Description cannot be empty")]
        [MinLength(20, ErrorMessage = "{0} should contain more than {1} charcters ")]
        public string ProjectDescription { get; set; }


        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }



    }
}
