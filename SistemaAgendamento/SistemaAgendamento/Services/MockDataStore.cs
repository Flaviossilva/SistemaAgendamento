using SistemaAgendamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAgendamento.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Flavio",Idade="31",Telefone="1138888888",RedeSocial = "flavio.insta", Descricao="Sobrancelha" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Fabiano",Idade="32",Telefone="113455555",RedeSocial = "test1.insta", Descricao="Cilios" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "joyce",Idade="21",Telefone="1136666666",RedeSocial = "test3.insta", Descricao="Bigode" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "rodrigo",Idade="11",Telefone="1122221111",RedeSocial = "teste5454.insta", Descricao="Barba" },
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