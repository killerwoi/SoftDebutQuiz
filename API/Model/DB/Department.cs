using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Model.DB
{
    public class Department
    {
        [Key]
        [Column("DepNo")]
        [MaxLength(20)]
        public string? DepNo { get; set; }

        [Column("DepName")]
        [MaxLength(255)]
        public string? DepName { get; set; }

        [Column("Location")]
        [MaxLength(100)]
        public string? Location { get; set; }

        #region Relation
        public ICollection<Employee>? Employees { get; set; }
        #endregion
    }
}
