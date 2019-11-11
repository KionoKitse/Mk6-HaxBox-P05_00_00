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
using Windows.Graphics.Display; //Brightness override


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mk6_HaxBox_P05_00_00
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public BrightnessOverride bo = BrightnessOverride.GetForCurrentView();
        private SharedFunctions ShareTools;

        public MainPage()
        {
            this.InitializeComponent();
            
            //Update the slider value and adjust brightness
            sldrBrightness.Value = SharedData.BrightnessLevel * 100;
            bo.SetBrightnessLevel(SharedData.BrightnessLevel, DisplayBrightnessOverrideOptions.None);
            bo.StartOverride();

            //Update the page title
            tbPageTitle.Text = "Main Page";
        }


        private void btnVehicleStats_Click(object sender, RoutedEventArgs e)
        {
            //Stop brightness override and navigate to page
            bo.StopOverride();
            this.Frame.Navigate(typeof(VehicleStatsPage));
        }

        private void btnNavigation_Click(object sender, RoutedEventArgs e)
        {
            //Stop brightness override and navigate to page
            bo.StopOverride();
            this.Frame.Navigate(typeof(NavigationPage));
        }

        private void btnDataAnalysis_Click(object sender, RoutedEventArgs e)
        {
            //Stop brightness override and navigate to page
            bo.StopOverride();
            this.Frame.Navigate(typeof(DataAnalysisPage));
        }

        private void btnMaintenance_Click(object sender, RoutedEventArgs e)
        {
            //Stop brightness override and navigate to page
            bo.StopOverride();
            this.Frame.Navigate(typeof(MaintenancePage));
        }


        //Top panel items
        private void btnFuelLogs_Click(object sender, RoutedEventArgs e)
        {
            //Stop brightness override and navigate to page
            bo.StopOverride();
            this.Frame.Navigate(typeof(FuelLogsPage));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            //Stop brightness override and navigate to page
            bo.StopOverride();
            this.Frame.Navigate(typeof(SettingsPage));
        }

        private void sldrBrightness_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //Get new level from slider and update BrightnessLevel
            double NewLevel = e.NewValue / 100;
            SharedData.BrightnessLevel = NewLevel;

            //Stop brightness override and restart with new level
            bo.StopOverride();
            bo.SetBrightnessLevel(SharedData.BrightnessLevel, DisplayBrightnessOverrideOptions.None);
            bo.StartOverride();
        }
    }
}
