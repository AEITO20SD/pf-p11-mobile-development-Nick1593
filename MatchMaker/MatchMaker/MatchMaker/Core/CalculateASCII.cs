using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MatchMaker.Interfaces;

namespace MatchMaker.Core
{
    public class CalculateASCII : Calculator, ICalculateASCII
    {
        public override async Task<int> CalculateAsync(Entry Name1, Entry Name2)
        {
            int result;
            int name1ASCII = await GetASCIIAsync(Name1);
            int name2ASCII = await GetASCIIAsync(Name2);
            result = 100 - (name1ASCII - name2ASCII);

            return result;
        }
        public async Task<int> GetASCIIAsync(Entry name)
        {
            int result = 0;
            foreach (char c in name.Text)
            {
                result += (int)c;
            }
            await Task.Run(() => result);
            return result;
        }
    }
}
