using GameManager.Lib.Models.Game;
using GameManager.Lib.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameManager.Lib.Services
{
    public class InventoryService : IInventoryService
    {
        private Player _player;

        public String FilePath
        {
            get 
            {
                var filename = $"{_player.Id}_v1.json";
                String basePath = Path.Combine(Environment.CurrentDirectory, @"inventory\");
                // combine with FilePath
                String filePath = Path.Combine(basePath, filename);
                
                // no inventory directory at all. create it.
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                return Path.Combine(basePath, filename);
            }
        }

        public InventoryService(Player player) 
        {
            _player = player;
        }

        // load items from json and convert to list of items
        public async Task<List<Item>> LoadItems()
        {
            try
            {
                // new user, no inventory yet
                if (!File.Exists(FilePath))
                {
                    return new List<Item>();
                }

                using (FileStream openStream = File.OpenRead(FilePath))
                {
                    List<Item>? items = await JsonSerializer.DeserializeAsync<List<Item>>(openStream);
                    return items ?? new List<Item>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // save list of items to json
        public async Task SaveItems(List<Item> items)
        {
            try
            {
                using (FileStream createStream = File.Create(FilePath))
                {
                    await JsonSerializer.SerializeAsync(createStream, items);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
