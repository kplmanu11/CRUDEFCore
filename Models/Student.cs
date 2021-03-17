using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage ="Required")]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CellNo { get; set; }

        public int DepId { get; set; }

        [NotMapped]
        public string Department { get; set; }

    }
}
