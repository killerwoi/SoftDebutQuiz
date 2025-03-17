using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model.DB
{
    public class EmployeeBackup
    {
        [Key]
        [Column("EmpNum")]
        [MaxLength(20)]
        public string? EmpNum { get; set; }

        [Column("EmpName")]
        [MaxLength(255)]
        public string? EmpName { get; set; }

        [Column("Salary")]
        public decimal Salary { get; set; }

        [Column("Position")]
        [MaxLength(100)]
        public string? Position { get; set; }
    }
}
