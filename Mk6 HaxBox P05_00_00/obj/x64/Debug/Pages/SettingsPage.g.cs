﻿#pragma checksum "C:\Users\DevOtter\Documents\Visual Studio 2019\P05_00_00  Mk6 HaxBox\branches\MaintenanceSchedule\Mk6 HaxBox P05_00_00\Pages\SettingsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDA9327DDB9AB97A500EEF7C72736F3D"
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
    partial class SettingsPage : 
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
            case 2: // Pages\SettingsPage.xaml line 43
                {
                    this.btnBack = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBack).Click += this.btnBack_Click;
                }
                break;
            case 3: // Pages\SettingsPage.xaml line 27
                {
                    this.tbPageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Pages\SettingsPage.xaml line 38
                {
                    this.btnDispMode = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5: // Pages\SettingsPage.xaml line 39
                {
                    this.btnFuelLogs = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnFuelLogs).Click += this.btnFuelLogs_Click;
                }
                break;
            case 6: // Pages\SettingsPage.xaml line 40
                {
                    this.txtBatteryLevel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Pages\SettingsPage.xaml line 41
                {
                    this.btnSettings = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSettings).Click += this.btnSettings_Click;
                }
                break;
            case 8: // Pages\SettingsPage.xaml line 34
                {
                    this.txtBrightL = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Pages\SettingsPage.xaml line 35
                {
                    this.sldrBrightness = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.sldrBrightness).ValueChanged += this.sldrBrightness_ValueChanged;
                }
                break;
            case 10: // Pages\SettingsPage.xaml line 36
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

