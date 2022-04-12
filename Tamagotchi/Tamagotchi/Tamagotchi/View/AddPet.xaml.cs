using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tamagotchi.Services;
using Tamagotchi.ViewModels;

namespace Tamagotchi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPet : ContentPage
    {
        private AddPetViewModel _viewModel;
        public AddPet(TamagotchiService service)
        {
            InitializeComponent();
            _viewModel = new AddPetViewModel(service);
            BindingContext = _viewModel;
        }
    }
}