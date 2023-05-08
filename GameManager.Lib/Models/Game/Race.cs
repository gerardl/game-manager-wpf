using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Game
{
    [Table("Race", Schema = "Game")]
    public class Race : Base.MasterData
    {
    }

    public enum Races
    {
        Human = 1,
        Elf,
        Drawf,
        Orc
    }
}
