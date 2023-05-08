using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using GameManager.UI.Views;
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
        public event EventHandler<MobSelectedEventArgs> MobSelected;
        
        public void SelectMob(Mob mob)
        {
            MobSelected?.Invoke(this, new MobSelectedEventArgs { Mob = mob });
        }
    }

    public class MobSelectedEventArgs : EventArgs
    {
        public Mob Mob { get; set; }
    }
}
