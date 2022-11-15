using System.ComponentModel;
using UserInterface.ViewModels;
using Xamarin.Forms;

namespace UserInterface.Views
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