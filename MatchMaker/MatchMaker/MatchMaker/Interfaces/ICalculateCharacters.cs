using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace MatchMaker.Interfaces
{
    public interface ICalculateCharacters
    {
        public Task<int> CountVowelsOrConsonantsAsync(string searchIn, string searchFor, bool inverse);
        public Task<int> SameFirstLetterTypeAsync(string name1, string name2);
        public Task<int> IsEqualAsync(int name1, int name2, int reward);
    }
}
