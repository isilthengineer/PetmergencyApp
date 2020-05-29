using System;
using System.Collections.Generic;
using System.Linq;
using Petmergency.Core;
using Petmergency.Helpers;
using Petmergency.Models;
using Windows.UI.Xaml.Controls;

namespace Petmergency.Views
{
    public sealed partial class SearchCityView : Page
    {
        public static List<VetModel> vetList = new List<VetModel>();


        public SearchCityView()
        {
            this.InitializeComponent();
            this.listView.ItemsSource = CityHelper.getCities();
        }


        private async void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            progress.IsIndeterminate = true;

            try
            {
                SearchVetView.City = listView.SelectedItem as string;
                vetList = await DataClient.Instance.GetVetsInCity(SearchVetView.City);

                Frame.Navigate(typeof(SearchTownView));
            }

            catch (Exception)
            {

            }

            progress.IsIndeterminate = false;
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            string filter = sender.Text.ToUpper();
            listView.ItemsSource = CityHelper.getCities().Where(s => (s).ToUpper().Contains(filter));
        }
    }
}