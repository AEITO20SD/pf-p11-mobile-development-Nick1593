using Xamarin.Forms;
using Tamagotchi.Services;
using Tamagotchi.ViewModels;

namespace Tamagotchi
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;
        public MainPage(TamagotchiService service)
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel(service);
            BindingContext = _viewModel;
        }
    }
}
