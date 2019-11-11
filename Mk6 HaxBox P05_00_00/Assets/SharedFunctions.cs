using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display; //Brightness overide
using Windows.Storage;          //Local Cache

namespace Mk6_HaxBox_P05_00_00
{
    class SharedFunctions
    {
        
        public BrightnessOverride bo = BrightnessOverride.GetForCurrentView();
        StorageFolder localCacheFolder = ApplicationData.Current.LocalCacheFolder;

        //Function to get the user settings from the cache
        public async void GetSettingsCacheAsync()
        {
            StorageFile sampleFile;
            try
            {
                //Check if the file is exists
                sampleFile = await localCacheFolder.GetFileAsync("dataFile.txt");
                try
                {
                    //Read the file and set the cache settings variables
                    var readFile = await FileIO.ReadLinesAsync(sampleFile);
                    SharedData.BrightnessLevel = double.Parse(readFile[0]);
                    SharedData.HelloInt = int.Parse(readFile[1]);
                }
                catch (Exception e)
                {
                    //Write the file
                    List<string> VarDefaults = new List<string>();
                    VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                    VarDefaults.Add(SharedData.HelloInt.ToString());       //Something else
                    await FileIO.WriteLinesAsync(sampleFile, VarDefaults);
                }

            }
            catch (Exception e)
            {
                //Create the file
                sampleFile = await localCacheFolder.CreateFileAsync("dataFile.txt");
                List<string> VarDefaults = new List<string>();
                VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                VarDefaults.Add(SharedData.HelloInt.ToString());       //Something else
                await FileIO.WriteLinesAsync(sampleFile, VarDefaults);
            }
        }

        //Function to save the user settings to the cache
        public async void SaveSettingsCacheAsync()
        {
            StorageFile sampleFile;
            try
            {
                //Check if the file is exists
                sampleFile = await localCacheFolder.GetFileAsync("dataFile.txt");
                try
                {
                    //Write the file
                    List<string> VarDefaults = new List<string>();
                    VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                    VarDefaults.Add(SharedData.HelloInt.ToString());       //Something else
                    await FileIO.WriteLinesAsync(sampleFile, VarDefaults);
                }
                catch (Exception e)
                {
                    //TODO: Some error code
                }
            }
            catch (Exception e)
            {
                //Create the file
                sampleFile = await localCacheFolder.CreateFileAsync("dataFile.txt");
                List<string> VarDefaults = new List<string>();
                VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                VarDefaults.Add(SharedData.HelloInt.ToString());       //Something else
                await FileIO.WriteLinesAsync(sampleFile, VarDefaults);
            }
        }


        public void Set_Full_Brightness()
        {
            //Create BrightnessOverride object
             bo = BrightnessOverride.GetForCurrentView();

            //Set override brightness to full brightness even when battery is low
            bo.SetBrightnessScenario(DisplayBrightnessScenario.FullBrightness, DisplayBrightnessOverrideOptions.None);

            //Request to start the overriding process
            bo.StartOverride();

            //bo.SetBrightnessLevel(0.80, DisplayBrightnessOverrideOptions.UseDimmedPolicyWhenBatteryIsLow);
        }

        public void StopBrightnessOveride()
        {
            BrightnessOverride bo = BrightnessOverride.GetForCurrentView();
            bo.StopOverride();
        }
        public void SetBrightness(double level)
        {
            bo = BrightnessOverride.GetForCurrentView();
            bo.StopOverride();
            bo.SetBrightnessLevel(level, DisplayBrightnessOverrideOptions.None);
            bo.StartOverride();
        }

    }
}
