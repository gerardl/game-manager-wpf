using GameManager.Lib.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameManager.Lib.Services
{
    internal interface IInventoryService
    {
        Task<List<Item>> LoadItems();
        Task SaveItems(List<Item> items);
    }
}
