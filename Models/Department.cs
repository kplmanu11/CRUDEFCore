using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Department
    {
        [Key]
        [Required(ErrorMessage ="Required")]
        public int ID { get; set; }

        [Required(ErrorMessage ="Required")]
        public string DepartmentName { get; set; }

    }
}
