using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi.CustomMarkup
{
    [ContentProperty(nameof(Source))]
    public class EmbeddedImageExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource(Source, typeof(EmbeddedImageExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
