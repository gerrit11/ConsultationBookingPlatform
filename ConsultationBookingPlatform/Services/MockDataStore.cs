﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultationBookingPlatform.Models;

namespace ConsultationBookingPlatform.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        readonly List<Item> dashBourdItem;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            dashBourdItem = new List<Item>()
            {
                new Item {Id = Guid.NewGuid().ToString(), Text = "Meeting 20/10/2020 10Pm", Description="Meeting with Bob"},
                new Item {Id = Guid.NewGuid().ToString(), Text = "New Update 2021", Description="Cloud database suport"},
                new Item {Id = Guid.NewGuid().ToString(), Text = "Meeting 10/12/2020 9am", Description="Meeting with Alice"}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<bool> AddItemAsyncDash(Item item)
        {
            dashBourdItem.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateItemAsyncDash(Item item)
        {
            var oldItem = dashBourdItem.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            dashBourdItem.Remove(oldItem);
            dashBourdItem.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsyncDash(string id)
        {
            var oldItem = dashBourdItem.Where((Item arg) => arg.Id == id).FirstOrDefault();
            dashBourdItem.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Item> GetItemAsyncDash(string id)
        {
            return await Task.FromResult(dashBourdItem.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<IEnumerable<Item>> GetItemsAsyncDash(bool forceRefresh = false)
        {
            return await Task.FromResult(dashBourdItem);
        }
    }
}