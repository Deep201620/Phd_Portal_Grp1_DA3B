using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phd_Portal_Grp1_DA3B.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialNo { get; set; }

        [Display(Name = "User Id")]

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual UserInfo user { get; set; }


        [Display(Name = "Enrollment No")]
        [Required]
        public long EnrollmentNo { get; set; }

        [Display(Name = "Date of Birth")]
        //[DisplayFormat(DataFormatString = "dd-mm-yyyy")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Profile Image")]
        public string ImageUrl { get; set; }


    }
}
