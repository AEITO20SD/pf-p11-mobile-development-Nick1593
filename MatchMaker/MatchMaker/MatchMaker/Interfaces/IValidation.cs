using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MatchMaker.Interfaces
{
    public interface IValidation
    {
        public Task<bool> IsValidAsync(IList<Entry> Entry);
        public Task<bool> IsNotNullAsync(Entry Entry);
    }
}
