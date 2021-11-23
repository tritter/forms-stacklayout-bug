using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackLayoutAndroidBug.Models;

namespace StackLayoutAndroidBug.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "1 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "3 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "4 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "5 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "6 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "7 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "8 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "9 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "10 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "11 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "12 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "13 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "14 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "15 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "16 item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "17 item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}