using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Model
{
    public partial class EmployeeLeave
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public bool? IsCancelled { get; set; }
        public string Comments { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
