using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model.DB
{
    public class Employee
    {
        [Key]
        [Column("EmpNum")]
        [MaxLength(20)]
        public string? EmpNum { get; set; }

        [Column("EmpName")]
        [MaxLength(255)]
        public string? EmpName { get; set; }

        [DefaultValue(null)]
        [Column("HireDate")]
        public DateOnly? HireDate { get; set; }

        [Column("Salary")]
        public decimal Salary { get; set; }

        [Column("PositionNo")]
        [MaxLength(20)]
        public string? PositionNo { get; set; }

        [Column("DepNo")]
        [MaxLength(20)]
        public string? DepNo { get; set; }

        [Column("HeadNo")]
        [MaxLength(20)]
        public string? HeadNo { get; set; }

        #region Relation
        public Department? Department { get; set; }
        public Position? Position { get; set; }
        #endregion
    }
}
