using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeptEmployeeMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOJ { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }


        public Department Department { get; set; }


        public Salary salary { get; set; }

    }
}