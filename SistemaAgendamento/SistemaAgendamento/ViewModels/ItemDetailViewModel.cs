using SistemaAgendamento.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SistemaAgendamento.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string nome;
        private string descricao;
        private string idade;
        private string telefone;
        private string redesocial;

        public string Id { get; set; }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Idade
        {
            get => idade;
            set => SetProperty(ref idade, value);
        }
        public string Telefone
        {
            get => telefone;
            set => SetProperty(ref telefone, value);
        }
        public string Redesocial
        {
            get => redesocial;
            set => SetProperty(ref redesocial, value);
        }
        public string Descricao
        {
            get => descricao;
            set => SetProperty(ref descricao, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Nome = item.Nome;
                Idade =item.Idade;
                Telefone = item.Telefone;
                Redesocial=item.RedeSocial; 
                Descricao = item.Descricao;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
