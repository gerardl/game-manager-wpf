using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI.Models
{
    internal class PlayerViewModel
    {
        private readonly IGameService _gameService;
        public Player Player { get; set; }
        public List<Race> Races { get; set; }
        public event EventHandler<PlayerSavedEventArgs> PlayerSaved;
        public event EventHandler<PlayerDeletedEventArgs> PlayerDeleted;

        public PlayerViewModel(IGameService gameService, Player player, List<Race> races) 
        {
            _gameService = gameService;
            Player = player;
            Races = races;
        }

        public async Task Save()
        {
            if (Player.Id == 0)
            {
                Player.Id = await _gameService.AddPlayerAsync(Player);
            }
            else
            {
                await _gameService.UpdatePlayerAsync(Player);
            }
            PlayerSaved?.Invoke(this, new PlayerSavedEventArgs { Player = Player });
        }

        public async Task Delete()
        {
            if (Player.Id != 0)
            {
                await _gameService.DeletePlayerAsync(Player);
            }
            PlayerDeleted?.Invoke(this, new PlayerDeletedEventArgs { Player = Player });
            Player = new Player();
        }

        public class PlayerSavedEventArgs : EventArgs
        {
            public Player Player { get; set; }
        }

        public class PlayerDeletedEventArgs : EventArgs
        {
            public Player Player { get; set; }
        }
    }
}
