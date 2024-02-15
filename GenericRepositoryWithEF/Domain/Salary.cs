namespace GenericRepositoryWithEF.Domain
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public string Month { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
