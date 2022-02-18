using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MatchMaker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnNextPageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
        async void OnClickCalculateMatch(object sender, EventArgs e)
        { 
            string primary = PrimaryName.Text;
            string secondary = SecondaryName.Text;
            
            if (primary == null || secondary == null)
            {
                TxtResult.Text = "Fill in all the fields";
                TxtResult.TextColor = Color.Red;
                Hart.IsVisible = false;
            }
            else
            {
                int duration = (primary.Length + secondary.Length) * 200;
                
                Hart.IsVisible = false;
                TxtResult.IsVisible = false;
                Loading.IsRunning = true;
                Loading.IsVisible = true;
                await Task.Delay(duration);
                Loading.IsRunning = false;
                Loading.IsVisible = false;

                if (Preferences.Get("math_type", false) == false)
                {
                    TxtResult.Text = CalculateMatchASCII(primary, secondary);
                }
                else if(Preferences.Get("math_type", false) == true) 
                { 
                    TxtResult.Text = CalculateCharMatch(primary, secondary) + " points";
                }
                Hart.IsVisible = true;
                TxtResult.IsVisible = true;
                TxtResult.TextColor = Color.Green;
            }
        }
        private string CalculateMatchASCII(string primary, string secondary)
        {
            int result;
            int primaryASCII = GetASCII(primary);
            int secondaryASCII = GetASCII(secondary);
            result = 100 - (primaryASCII - secondaryASCII);

            return result.ToString() + "%";
        }
        private string CalculateCharMatch(string primary, string secondary)
        {
            int result = 0;
            string vowels = "aeiouy";
            int primaryLength = primary.Length;
            int secondaryLength = secondary.Length;

            result += IsEqual(primaryLength, secondaryLength, 20);

            result += SameFirstLetterType(primary, secondary);

            int countVowelsPrimary = CountChars(primary, vowels, false);
            int countVowelsSecondary = CountChars(secondary, vowels, false);
            
            result += IsEqual(countVowelsPrimary, countVowelsSecondary, 20);

            int countConsPrimary = CountChars(primary, vowels, true);
            int countConsSecondary = CountChars(secondary, vowels, true);

            result += IsEqual(countConsPrimary, countConsSecondary, 20);

            int countLove = CountChars(secondary, "love", false);

            result += 5 * countLove;

            return result.ToString();
        }
        private int GetASCII(string x)
        {
            int Result = 0;
            foreach (char c in x)
            {
                Result += (int)c;
            }
            return Result;
        }
        private int CountChars(string searchIn, string searchFor, bool inverse)
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
            return inverse ? resultReverse : result;
        }
        private int IsEqual(int primary, int secondary, int reward)
        {
            int localReward = 0;

            if (primary == secondary)
            {
                localReward = reward;
            }
            return localReward;
        }
        private int SameFirstLetterType(string primary, string secondary)
        {
            int result = 0;
            string vowels = "aeiouy";

            char firstLetterPrimary = primary[0];
            char firstLetterSecondary = secondary[0];

            bool vowelFirstLetterPrimary = vowels.Contains(firstLetterPrimary);
            bool vowelFirstLetterSecondary = vowels.Contains(firstLetterSecondary);

            if(vowelFirstLetterPrimary && vowelFirstLetterSecondary)
            {
                result = 10;
            }
            else if(!vowelFirstLetterPrimary && !vowelFirstLetterSecondary)
            {
                result = 10;
            }

            return result;
        }
    }
}
