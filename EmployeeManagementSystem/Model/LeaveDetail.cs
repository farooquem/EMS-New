using System;

namespace EmployeeManagementSystem.Model
{
    public class LeaveDetail
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NoOfDate { get; set; }
        public string LeaveReason { get; set; }
        public bool Approved { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
