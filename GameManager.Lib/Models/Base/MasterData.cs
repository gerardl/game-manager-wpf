using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Base
{
    public abstract class MasterData : EntityBase, ISortable
    {
        // These entities all have controlled Ids
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public virtual string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
