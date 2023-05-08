using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.UI.Models
{
    internal class PlayerViewModel
    {
        public Player Player { get; set; }
        public List<Race> Races { get; set; }
        public IGameService GameService { get; set; }
    }
}
