using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

using HackXamarin.Helpers;
using HackXamarin.Models;
using HackXamarin.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace HackXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.PropertyChanged += OnPropertyChanged;
            Title = "Browse";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

            LoadItemsCommand.Execute(null);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem) && SelectedItem != null)
            {
                var name = "DetailPage?id=" + SelectedItem.Id;
                SelectedItem = null;
                NavigationService.NavigateAsync(name);
            }
        }


        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}