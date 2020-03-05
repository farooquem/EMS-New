using System;

namespace EmployeeManagementSystem.Model
{
    public class InOutDetail
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OfficeDate { get; set; }
        public TimeSpan? InTIme { get; set; }
        public TimeSpan? OutTime { get; set; }
    
    }
}
