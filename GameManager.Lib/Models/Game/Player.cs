using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Game
{
    [Table("Player", Schema = "Game")]
    public class Player : Base.CharacterBase
    {
    }
}
