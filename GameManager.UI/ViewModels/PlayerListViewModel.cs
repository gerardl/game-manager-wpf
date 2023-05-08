using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI.ViewModels
{
    internal class PlayerListViewModel
    {
        public List<Player> Players { get; set; }
        public IGameService GameService { get; set; }
        public event EventHandler<PlayerSelectedEventArgs> PlayerSelected;

        public void SelectPlayer(Player player)
        {
            PlayerSelected?.Invoke(this, new PlayerSelectedEventArgs { Player = player });
        }
    }

    public class PlayerSelectedEventArgs : EventArgs
    {
        public Player Player { get; set; }
    }
}
