﻿using GameManager.Lib.Models.Game;
using GameManager.Lib.Models.Inventory;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI.Models
{
    public class PlayerViewModel
    {
        private readonly IGameService _gameService;
        public Player Player { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Race> Races { get; set; }
        public event EventHandler<PlayerSavedEventArgs> PlayerSaved;
        public event EventHandler<PlayerDeletedEventArgs> PlayerDeleted;
        public event EventHandler<InventorySavedEventArgs> InventorySaved;

        public PlayerViewModel(IGameService gameService, Player player, List<Race> races) 
        {
            _gameService = gameService;
            Player = player;
            Races = races;
        }

        public async Task Save()
        {
            try
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
            catch (Exception)
            {
                throw;
            }

        }

        public async Task LoadInventory()
        {
            var invService = new InventoryService(Player);
            Inventory = await invService.LoadItems();
        }

        public async Task SaveInventory()
        {
            var invService = new InventoryService(Player);
            await invService.SaveItems(Inventory);
            InventorySaved?.Invoke(this, new InventorySavedEventArgs { Inventory = Inventory });
        }

        public async Task Delete()
        {
            try
            {
                if (Player.Id != 0)
                {
                    await _gameService.DeletePlayerAsync(Player);
                }
                PlayerDeleted?.Invoke(this, new PlayerDeletedEventArgs { Player = Player });
                Player = new Player();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public class PlayerSavedEventArgs : EventArgs
        {
            public Player Player { get; set; }
        }

        public class PlayerDeletedEventArgs : EventArgs
        {
            public Player Player { get; set; }
        }

        public class InventorySavedEventArgs : EventArgs
        {
            public List<Item> Inventory { get; set; }
        }
    }
}
