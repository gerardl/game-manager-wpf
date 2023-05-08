using GameManager.Lib.Models.Game;
using GameManager.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Services
{
    public interface IGameService
    {
        Task<List<Player>> GetPlayersAsync();
        Task<List<Race>> GetRacesAsync();
        Task<Player> GetPlayerAsync(int id);
        Task<int> AddPlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
    }
}
