using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MatchMaker.Interfaces
{
    public interface ICalculateASCII
    {
        public Task<int> GetASCIIAsync(Entry name);
    }
}
