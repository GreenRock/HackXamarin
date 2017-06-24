using HackXamarin;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace HackXamarin.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new HackXamarin.App(new UWPInitializer()));
        }
    }

    public class UWPInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
        }
    }
}