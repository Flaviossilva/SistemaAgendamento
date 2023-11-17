using SistemaAgendamento.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SistemaAgendamento.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}