using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidCastException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!this.items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            var item = this.items.FirstOrDefault(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
