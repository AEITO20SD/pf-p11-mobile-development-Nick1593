using System.Threading.Tasks;
using Xamarin.Forms;

namespace MatchMaker.Core
{
    public abstract class Calculator
    {
        public abstract Task<int> CalculateAsync(Entry Name1, Entry Name2);
    }
}
