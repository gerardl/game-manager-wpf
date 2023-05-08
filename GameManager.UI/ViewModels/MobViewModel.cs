using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.UI.ViewModels
{
    internal class MobViewModel
    {
        private readonly IGameService _gameService;
        public Mob Mob { get; set; }
        public List<Race> Races { get; set; }

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
        }
    }
}
