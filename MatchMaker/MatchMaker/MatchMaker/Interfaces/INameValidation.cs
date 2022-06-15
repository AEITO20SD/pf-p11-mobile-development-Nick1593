using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MatchMaker.Interfaces
{
    public interface INameValidation
    {
        public Task<bool> IsAlphabetical(Entry Entry);
    }
}
