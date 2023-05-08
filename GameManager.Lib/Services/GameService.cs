using GameManager.Lib.Models.Game;
using GameManager.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Services
{
    public class GameService : IGameService
    {
        private readonly IDataRepository _dataRepository;

        public GameService(IDataRepository dataRepository) 
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _dataRepository.GetAllAsync<Player>();
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _dataRepository.GetEntityAsync<Player>(id);
        }

        public async Task<int> AddPlayerAsync(Player player)
        {
            return (await _dataRepository.AddEntityAsync(player)).Id;
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            await _dataRepository.UpdateEntityAsync(player);
        }

        public async Task DeletePlayerAsync(Player player)
        {
            await _dataRepository.DeleteEntityAsync(player);
        }

        public async Task<List<Mob>> GetMobsAsync()
        {
            return await _dataRepository.GetAllAsync<Mob>();
        }

        public async Task<Mob> GetMobAsync(int id)
        {
            return await _dataRepository.GetEntityAsync<Mob>(id);
        }

        public async Task<int> AddMobAsync(Mob mob)
        {
            return (await _dataRepository.AddEntityAsync(mob)).Id;
        }

        public async Task UpdateMobAsync(Mob mob)
        {
            await _dataRepository.UpdateEntityAsync(mob);
        }

        public async Task<List<Race>> GetRacesAsync()
        {
            return await _dataRepository.GetAllAsync<Race>();
        }

        public async Task DeleteMobAsync(Mob mob)
        {
            await _dataRepository.DeleteEntityAsync(mob);
        }
    }
}
