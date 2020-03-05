using System;

namespace EmployeeManagementSystem.Model
{
    public class SalarySlip
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int FinancialYear { get; set; }
        public int FinancialMonth { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal EPF { get; set; }
        public decimal CashInHand { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}