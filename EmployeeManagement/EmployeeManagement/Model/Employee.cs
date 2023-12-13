using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required."), Column(TypeName = "Varchar(25)")]
        [StringLength(100, ErrorMessage = "Name should not execeed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary should be non-negative number.")]
        [Range(0, 10000000)]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Location is required."), Column(TypeName = "Varchar(25)")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Email is required."), Column(TypeName = "Varchar(25)")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required."), Column(TypeName = "Varchar(25)")]
        [StringLength(50, ErrorMessage = "Department should not execeed 50 characters.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Qualification is required."), Column(TypeName = "Varchar(25)")]
        [StringLength(100, ErrorMessage = "Qualification should not exceed 100 characters.")]
        public string Qualification { get; set; }

        DateTime _createdDate;
        public DateTime? CreatedDate
        {
            set 
            {
                _createdDate = DateTime.Now;
            }
            get
            {
                return _createdDate;
            }
        }
        public DateTime? UpdatedDate { get; set; }
    }
}
