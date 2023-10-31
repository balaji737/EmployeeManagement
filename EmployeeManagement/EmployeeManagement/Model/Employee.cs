using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name should not execeed 100 characters.")] 
        public string Name { get; set; }

        [Range(0, 10000000, ErrorMessage = "Salary should be non-negative number")]
        public int Salary { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [StringLength(50, ErrorMessage = "Department should not execeed 50 characters.")]
        public string Department { get; set; }

        [Required]
        public string Qualification { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


    }
}
