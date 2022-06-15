using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MatchMaker.Interfaces;

namespace MatchMaker.Core
{
    public abstract class Validation : IValidation
    {
        public virtual async Task<bool> IsValidAsync(IList<Entry> Entries)
        {
            bool isValid = true;

            foreach(var singleEntry in Entries)
            {
                if (isValid)
                {
                    isValid = await IsNotNullAsync(singleEntry);
                }
            }

            return isValid;
        }
        public virtual async Task<bool> IsNotNullAsync(Entry Entry)
        {
            bool isNotNull = false;

            if (Entry.Text == null || Entry.Text == "")
            {
                isNotNull = true;
            }

            await Task.Run(() => isNotNull);
            return isNotNull ? false : true;
        }
    }
}
