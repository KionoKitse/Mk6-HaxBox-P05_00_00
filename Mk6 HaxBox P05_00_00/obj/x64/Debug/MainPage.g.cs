﻿#pragma checksum "C:\Users\DevOtter\Documents\Visual Studio 2019\P05_00_00  Mk6 HaxBox\branches\NavigationAndTopBar\Mk6 HaxBox P05_00_00\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B65B70AB26CE337703F42D778AB81874"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mk6_HaxBox_P05_00_00
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 45
                {
                    this.btnVehicleStats = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnVehicleStats).Click += this.btnVehicleStats_Click;
                }
                break;
            case 3: // MainPage.xaml line 46
                {
                    this.btnNavigation = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnNavigation).Click += this.btnNavigation_Click;
                }
                break;
            case 4: // MainPage.xaml line 47
                {
                    this.btnDataAnalysis = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDataAnalysis).Click += this.btnDataAnalysis_Click;
                }
                break;
            case 5: // MainPage.xaml line 48
                {
                    this.btnMaintenance = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnMaintenance).Click += this.btnMaintenance_Click;
                }
                break;
            case 6: // MainPage.xaml line 27
                {
                    this.tbPageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 38
                {
                    this.btnDispMode = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 8: // MainPage.xaml line 39
                {
                    this.btnFuelLogs = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnFuelLogs).Click += this.btnFuelLogs_Click;
                }
                break;
            case 9: // MainPage.xaml line 40
                {
                    this.txtBatteryLevel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // MainPage.xaml line 41
                {
                    this.btnSettings = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSettings).Click += this.btnSettings_Click;
                }
                break;
            case 11: // MainPage.xaml line 34
                {
                    this.txtBrightL = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // MainPage.xaml line 35
                {
                    this.sldrBrightness = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.sldrBrightness).ValueChanged += this.sldrBrightness_ValueChanged;
                }
                break;
            case 13: // MainPage.xaml line 36
                {
                    this.txtBrightH = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
