using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MatchMaker.Interfaces;

namespace MatchMaker.Core
{
    public class CalculateCharacters : Calculator, ICalculateCharacters
    {
        private static readonly string _vowels = "aeiouy";
        private readonly char[] _vowelsArray = _vowels.ToCharArray();
        private static readonly string _love = "love";
        public override async Task<int> CalculateAsync(Entry name1, Entry name2)
        {
            
            var countVowelsPrimary = await CountVowelsOrConsonantsAsync(name1.Text, _vowels, false);
            var countVowelsSecondary = await CountVowelsOrConsonantsAsync(name2.Text, _vowels, false);
            var countConsPrimary = await CountVowelsOrConsonantsAsync(name1.Text, _vowels, true);
            var countConsSecondary = await CountVowelsOrConsonantsAsync(name2.Text, _vowels, true);
            var countLove = await CountVowelsOrConsonantsAsync(name2.Text, _love, false);

            /*Task.WaitAll(countVowelsPrimary, countVowelsSecondary, countConsPrimary, countConsSecondary, countLove);*/

            int result = 0;
            result += await IsEqualAsync(name1.Text.Length, name2.Text.Length, 20);
            result += await SameFirstLetterTypeAsync(name1.Text, name2.Text);
            result += await IsEqualAsync(countVowelsPrimary, countVowelsSecondary, 20);
            result += await IsEqualAsync(countConsPrimary, countConsSecondary, 20);
            result += 5 * countLove;

            /*await Task.WaitAll(result);*/

            return result;
        }
        public async Task<int> CountVowelsOrConsonantsAsync(string searchIn, string searchFor, bool inverse)
        {
            int result = 0;
            int resultReverse = 0;
            foreach (char x in searchIn)
            {
                if (searchFor.Contains(x))
                {
                    result++;
                }
                else
                {
                    resultReverse++;
                }
            }
            await Task.Run(() => result);
            return inverse ? resultReverse : result;
        }
        public async Task<int> SameFirstLetterTypeAsync(string name1, string name2)
        {
            bool firstLetterIsVowelName1 = _vowelsArray.Contains(name1[0]);
            bool firstLetterIsVowelName2 = _vowelsArray.Contains(name2[0]);

            bool sameFirstLetterType = false;

            if (firstLetterIsVowelName1 == firstLetterIsVowelName2)
            {
                sameFirstLetterType = true;
            }

            await Task.Run(() => sameFirstLetterType);
            return sameFirstLetterType ? 10 : 0;
        }
        public async Task<int> IsEqualAsync(int countName1, int countName2, int reward)
        {
            bool isEqual = false;

            if (countName1 == countName2)
            {
                isEqual = true;
            }

            await Task.Run(() => isEqual);
            return isEqual ? reward : 0;
        }
    }
}
