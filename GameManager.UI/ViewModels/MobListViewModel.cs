using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.UI.ViewModels
{
    internal class MobListViewModel
    {
        public List<Mob> Mobs { get; set; }
        public IGameService GameService { get; set; }
    }
}
