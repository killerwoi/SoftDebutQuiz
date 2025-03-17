using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Model.DB
{
    public class Position
    {
        [Key]
        [Column("PositionNo")]
        [MaxLength(20)]
        public string? PositionNo { get; set; }

        [Column("PositionName")]
        [MaxLength(255)]
        public string? PositionName { get; set; }

        #region Relation
        public ICollection<Employee>? Employees { get; set; }
        #endregion
    }
}
