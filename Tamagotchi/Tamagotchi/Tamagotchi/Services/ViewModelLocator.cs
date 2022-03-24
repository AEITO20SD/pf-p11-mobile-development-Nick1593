using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Nancy.TinyIoc;

namespace Tamagotchi.Services
{
    public class ViewModelLocator
    {
        private static TinyIoCContainer _container;
        public ViewModelLocator()
        {
            _container = new TinyIoCContainer();
        }
        public void SetInjections()
        {
            _container.Register<ITamagotchiInterface, RequestProvider>();
        }
    }
}
