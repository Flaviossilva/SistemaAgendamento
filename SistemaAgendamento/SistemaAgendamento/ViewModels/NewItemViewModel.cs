using SistemaAgendamento.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SistemaAgendamento.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nome)
                && !String.IsNullOrWhiteSpace(descricao);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = Nome,
                Descricao = Descricao,
                Telefone = Telefone,
                Idade = Idade,
                RedeSocial = Redesocial,
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
