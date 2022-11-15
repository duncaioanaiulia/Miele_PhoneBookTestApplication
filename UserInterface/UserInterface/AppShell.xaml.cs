using System;
using System.Collections.Generic;
using UserInterface.ViewModels;
using UserInterface.Views;
using Xamarin.Forms;

namespace UserInterface
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
