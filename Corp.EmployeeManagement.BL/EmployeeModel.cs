using System;
using System.ComponentModel.DataAnnotations;
namespace Corp.EmployeeManagement.BL
{
    public class EmployeeModel
    {
        [Required]
        public int? ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        [MaxLength(10)]
        public string Contact { get; set; }
        [Required]
        [MaxLength(3)]
        public string BloodGroup { get; set; }
        public string Errors {get; set;}
    }
}
