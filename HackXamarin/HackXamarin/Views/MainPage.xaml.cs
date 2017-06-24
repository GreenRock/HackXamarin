using System;

using HackXamarin.Models;
using HackXamarin.ViewModels;

using Xamarin.Forms;

namespace HackXamarin.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);*/
        }
    }
}
