using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPDatabaseSample.code;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPDatabaseSample.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewEmployee : Page
    {
        public AddNewEmployee()
        {
            this.InitializeComponent();
        }

        const string connectionString1 = @"Data Source=DESKTOP-EUATNCH;Initial Catalog=EmployeesDB;Integrated Security=SSPI";

        private void AutoSuggestRace_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource = this.GetRaceSuggestion(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new string[] { "No Suggestions..." };
                }
            }
        }

        private void AutoSuggestBoxMaritalStatus_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource = this.GetMaritalSuggestion(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new string[] { "No Suggestions..." };
                }
            }
        }


        private void AutoSuggestState_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource = this.GetSuggestions(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new string[] { "No Suggestions..." };
                }
            }
        }

        private string[] stateSuggestion = new string[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Conneticuit", "Deleware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };

        private string[] maritalStatusSuggestion = new string[] {"Single", "Married", "Divorced", "Separated", "Widowed" };

        private string[] raceSuggestion = new string[] {"White (Caucasian)", "Black (African-American)", "Asian (Oriental)", "Middle Eastern", "Two or More Races" };

        private string[] GetRaceSuggestion(string text)
        {
            string[] result = null;

            result = raceSuggestion.Where(x => x.Contains(text)).ToArray();

            return result;
        }

        private string[] GetMaritalSuggestion(string text)
        {
            string[] result = null;

            result = maritalStatusSuggestion.Where(x => x.Contains(text)).ToArray();

            return result;
        }

        private string[] GetSuggestions(string text)
        {
            string[] result = null;

            result = stateSuggestion.Where(x => x.Contains(text)).ToArray();

            return result;
        }

        private void isReHire_Toggled(object sender, RoutedEventArgs e)
        {

        }
    }
}
