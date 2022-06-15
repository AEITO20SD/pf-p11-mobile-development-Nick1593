using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MatchMaker.Interfaces;
using Xamarin.Forms;

namespace MatchMaker.Core
{
    public class NameValidation : Validation, INameValidation
    {
        public override async Task<bool> IsValidAsync(IList<Entry> Entries)
        {
            bool isValid = true;

            foreach (var singleEntry in Entries)
            {
                if (isValid)
                {
                    isValid = await IsNotNullAsync(singleEntry);
                    isValid = await IsAlphabetical(singleEntry);
                }
            }

            return isValid;
        }
        public async Task<bool> IsAlphabetical(Entry Entry)
        {
            bool isAlphabetical = Regex.IsMatch(Entry.Text, @"^[a-zA-Z]+$");

            await Task.Run(() => isAlphabetical);
            return isAlphabetical;
        }
    }
}
