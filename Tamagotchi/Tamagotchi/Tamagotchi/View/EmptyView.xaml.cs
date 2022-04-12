using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyView : ContentPage
    {
        public EmptyView()
        {
            InitializeComponent();
        }
    }
}