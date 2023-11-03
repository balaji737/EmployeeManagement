using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name should not execeed 100 characters.")]
        public string Name { get; set; }

        [Range(0, 10000000, ErrorMessage = "Salary should be non-negative number")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [StringLength(50, ErrorMessage = "Department should not execeed 50 characters.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Qualification is required.")]
        [StringLength(100, ErrorMessage = "Qualification should not exceed 100 characters.")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }
    }
}
