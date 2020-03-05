namespace EmployeeManagementSystem.Model
{
    public class User
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }}
}