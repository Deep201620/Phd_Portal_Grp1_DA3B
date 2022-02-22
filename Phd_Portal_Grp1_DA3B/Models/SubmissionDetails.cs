using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Submission Details Model
/// </summary>

namespace Phd_Portal_Grp1_DA3B.Models
{
    [Table("SubmissionDetails")]
    public class SubmissionDetails
    {
        [Key]
        [Display(Name = "Submission Id")]
        public int SubmissionId { get; set; }


        [Display(Name = "Project Id")]
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project project { get; set; }

        [Display(Name = "Submission Date")]
        [DisplayFormat(DataFormatString = "dd-mm-yyyy")]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Submission File")]
        [Required]
        public string SubmissionFile { get; set; }

        [Display(Name = "Approval Status")]
        [Required]
        public bool ApprovalStatus { get; set; }
        
        [Display(Name = "Reviewed By")]
        public string ReviewedBy { get; set; }

        public string Remarks { get; set; }

    }
}
