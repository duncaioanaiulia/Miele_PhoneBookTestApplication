using System;
using System.Collections.Generic;
using System.ComponentModel;
using UserInterface.Models;
using UserInterface.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserInterface.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}