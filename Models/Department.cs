using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeptEmployeeMVC.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Employee> employees { get; set; }
    }
}