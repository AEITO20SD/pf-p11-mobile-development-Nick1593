using System.Threading.Tasks;
using Xamarin.Forms;
using MatchMaker.Interfaces;

namespace MatchMaker.Core
{
    public abstract class Calculator : ICalculator
    {
        public abstract Task<int> CalculateAsync(Entry Name1, Entry Name2);
    }
}
