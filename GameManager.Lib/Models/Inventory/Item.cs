using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Inventory
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
        public int SlotId { get; set; }
    }
}
