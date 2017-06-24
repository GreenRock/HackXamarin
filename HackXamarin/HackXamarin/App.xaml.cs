using HackXamarin.Models;
using HackXamarin.Services;
using HackXamarin.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HackXamarin
{
    public partial class App : PrismApplication
    {
        public App() : base(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
            
        }

        //TODO:
        /*public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }*/

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("Navigation/ItemsPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType(typeof(IDataStore<Item>), typeof(MockDataStore), new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
            Container.RegisterTypeForNavigation<ItemsPage>("ItemsPage");
            Container.RegisterTypeForNavigation<ItemDetailPage>("ItemDetailPage");
        }
    }
}
