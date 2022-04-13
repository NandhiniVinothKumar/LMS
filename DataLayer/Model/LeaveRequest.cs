using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        public string Employee_Name { get; set; }
        public string Employee_Id { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }
        [Display(Name = "End Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }
        public string LeaveType { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime Requested_Date { get; set; }

        [Display(Name = "Date Actioned")]
        public DateTime Date_Actioned { get; set; }
        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }
        public string ApprovedBy_Id { get; set; }
        public bool Cancelled { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string Comments { get; set; }

       



    }
}
