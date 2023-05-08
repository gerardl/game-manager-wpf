using GameManager.Lib.Models.Game;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Base
{
    public class CharacterBase : EntityBase, IMappedObject
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int Experience { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        
        [NotMapped]
        public int MaxHealth { get { return 1000 * (this.Constitution + (this.Strength / 2)) / 5; } }
        public int Strength { get; set; }
        public int Dexterity { get; set; }  
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal X { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Y { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Z { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rotation { get; set; }
    }
}
