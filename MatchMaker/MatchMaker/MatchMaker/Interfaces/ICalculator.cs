using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MatchMaker.Interfaces
{
    public interface ICalculator
    {
        public Task<int> CalculateAsync(Entry Name1, Entry Name2);
    }
}
