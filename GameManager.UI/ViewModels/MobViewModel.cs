using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameManager.UI.Models.PlayerViewModel;

namespace GameManager.UI.ViewModels
{
    internal class MobViewModel
    {
        private readonly IGameService _gameService;
        public Mob Mob { get; set; }
        public List<Race> Races { get; set; }
        public event EventHandler<MobSavedEventArgs> MobSaved;
        public event EventHandler<MobDeletedEventArgs> MobDeleted;

        public MobViewModel(IGameService gameService, Mob mob, List<Race> races)
        {
            _gameService = gameService;
            Mob = mob;
            Races = races;
        }

        public async Task Save()
        {
            if (Mob.Id == 0)
            {
                Mob.Id = await _gameService.AddMobAsync(Mob);
            }
            else
            {
                await _gameService.UpdateMobAsync(Mob);
            }
            MobSaved?.Invoke(this, new MobSavedEventArgs { Mob = Mob });
        }

        public async Task Delete()
        {
            if (Mob.Id != 0)
            {
                await _gameService.DeleteMobAsync(Mob);
            }
            MobDeleted?.Invoke(this, new MobDeletedEventArgs { Mob = Mob });
            Mob = new Mob();
        }
    }

    public class MobSavedEventArgs : EventArgs
    {
        public Mob Mob { get; set; }
    }

    public class MobDeletedEventArgs : EventArgs
    {
        public Mob Mob { get; set; }
    }
}
