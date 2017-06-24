using HackXamarin.Models;
using Prism.Navigation;

namespace HackXamarin.ViewModels
{
    public class ItemDetailPageViewModel : ViewModelBase
    {
        public ItemDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //TODO
            ItemInfo = DataStore.GetItemAsync(parameters["id"].ToString()).Result;

            Title = "Detail";
        }

        private Item _itemInfo;
        public Item ItemInfo
        {
            get => _itemInfo;
            set => SetProperty(ref _itemInfo, value);
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}