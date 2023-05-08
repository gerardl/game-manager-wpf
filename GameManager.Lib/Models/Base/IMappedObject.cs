using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Base
{
    /// <summary>
    /// Simple concept of something that can be mapped to a location and rotation.
    /// </summary>
    public interface IMappedObject
    {
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
