﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using MatchMaker.Core;
using MatchMaker.Interfaces;
using MatchMaker.Services;

namespace MatchMaker
{
    public partial class MainPage : ContentPage
    {
        private readonly ICalculator _calculateASCII;
        private readonly ICalculator _calculateCharacters;
        private readonly IValidation _nameValidation;
        private readonly ISettingsService _settingsService;
        private IList<Entry> _entries = new List<Entry>();
        private Label _textResult;
        private Image _hart;
        private ActivityIndicator _loading;
        private bool _preferences;

        public MainPage(ICalculator calculateASCII, ICalculator calculateCharacters, IValidation nameValidation, ISettingsService settingsService)
        {
            InitializeComponent();
            _calculateASCII = calculateASCII;
            _calculateCharacters = calculateCharacters;
            _nameValidation = nameValidation;
            _settingsService = settingsService;

            _textResult = (Label)this.FindByName("TextResult");
            _hart = (Image)this.FindByName("Hart");
            _loading = (ActivityIndicator)this.FindByName("Loading");
        }
        private async void OnNextPageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings(_settingsService));
        }
        #region Private Calculate Method
        private async void OnClickCalculateMatch(object sender, EventArgs e)
        {
            Entry entry1 = (Entry)this.FindByName("PrimaryName");
            Entry entry2 = (Entry)this.FindByName("SecondaryName");
            _entries.Add(entry1);
            _entries.Add(entry2);

            _textResult = (Label)this.FindByName("TxtResult");
            bool isValid = await _nameValidation.IsValidAsync(_entries);

            if (isValid)
            {
                _hart.IsVisible = false;
                _textResult.IsVisible = false;
                // Do loading time
                await LoadingTime();

                _preferences = _settingsService.GetSetting("math_type");

                if (_preferences)
                {
                    int result = await _calculateCharacters.CalculateAsync(entry1, entry2);
                    _textResult.Text = result.ToString() + " points";
                }
                else
                {
                    int result = await _calculateASCII.CalculateAsync(entry1, entry2);
                    _textResult.Text = result.ToString() + " %";
                }

                _hart.IsVisible = true;
                _textResult.IsVisible = true;
                _textResult.TextColor = Color.Green;
            }
            else
            {
                _textResult.Text = "Fields where not filled in correctly";
                _textResult.TextColor = Color.Red;
            }
        }
        #endregion
        #region Private Loading Method
        private async Task LoadingTime()
        {
            int duration = GetLengthEntries() * 200;
            _loading.IsRunning = true;
            _loading.IsVisible = true;
            await Task.Delay(duration);
            _loading.IsRunning = false;
            _loading.IsVisible = false;
        }
        private int GetLengthEntries()
        {
            int counter = 0;

            foreach (Entry entry in _entries)
            {
                foreach (char c in entry.Text)
                {
                    counter++;
                }
            }

            return counter;
        }
        #endregion
        #region Old Code
        /*async void OnClickCalculateMatch(object sender, EventArgs e)
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
        public string CalculateCharMatch(string primary, string secondary)
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
        }*/
        #endregion
    }
}
