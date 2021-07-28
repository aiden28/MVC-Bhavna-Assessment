using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeptEmployeeMVC.Models
{
    public class Salary
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public long SalaryAmount { get; set; }
    }
}