using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;          //Local Cache
using Windows.Graphics.Display; //Brightness overide

/*
>>> LOADING CACHE SETTINGS <<<
 * public async void GetSettingsCacheAsync()
 * public async void SaveSettingsCacheAsync()
*/
namespace Mk6_HaxBox_P05_00_00
{
    class SharedFunctions
    {
//>> LOADING CACHE SETTINGS <<        
        public BrightnessOverride bo = BrightnessOverride.GetForCurrentView();
        StorageFolder localCacheFolder = ApplicationData.Current.LocalCacheFolder;

        //Get the user settings from the cache
        public async void GetSettingsCacheAsync()
        {
            StorageFile SettingsFile;
            //Check if the file is exists
            try
            {
                SettingsFile = await localCacheFolder.GetFileAsync("CacheUserSettings.txt");

                //Read the file and set the cache settings variables
                try
                {
                    var readFile = await FileIO.ReadLinesAsync(SettingsFile);
                    SharedData.BrightnessLevel = double.Parse(readFile[0]);
                    SharedData.HelloInt = int.Parse(readFile[1]);
                }
                //Can't read the contents so write the hard coded values to the file
                catch (Exception e)
                {
                    List<string> VarDefaults = new List<string>();
                    VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                    VarDefaults.Add(SharedData.HelloInt.ToString());         //Something else
                    await FileIO.WriteLinesAsync(SettingsFile, VarDefaults);
                }

            }
            //Create the file and save the default hard coded settings to it
            catch (Exception e)
            {
                SettingsFile = await localCacheFolder.CreateFileAsync("CacheUserSettings.txt");
                List<string> VarDefaults = new List<string>();
                VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                VarDefaults.Add(SharedData.HelloInt.ToString());         //Something else
                await FileIO.WriteLinesAsync(SettingsFile, VarDefaults);
            }
        }
        //Save the user settings to the cache
        public async void SaveSettingsCacheAsync()
        {
            StorageFile SettingsFile;
            //Check if the file is exists
            try
            {
                SettingsFile = await localCacheFolder.GetFileAsync("CacheUserSettings.txt");
                //Write the user settings to the cache file
                try
                {
                    List<string> VarDefaults = new List<string>();
                    VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                    VarDefaults.Add(SharedData.HelloInt.ToString());         //Something else
                    await FileIO.WriteLinesAsync(SettingsFile, VarDefaults);
                }
                //Can't write the user settings to the cache file
                catch (Exception e)
                {
                    GenTools.ShowMessageAsync("⊙︿⊙ Can't write settings to cache file");
                }
            }
            //Create the file and save the default hard coded settings to it
            catch (Exception e)
            {
                SettingsFile = await localCacheFolder.CreateFileAsync("CacheUserSettings.txt");
                List<string> VarDefaults = new List<string>();
                VarDefaults.Add(SharedData.BrightnessLevel.ToString());  //BrightnessLevel
                VarDefaults.Add(SharedData.HelloInt.ToString());         //Something else
                await FileIO.WriteLinesAsync(SettingsFile, VarDefaults);
            }
        }


    }
}
/*
***** ROLL THE CREDITS *****
>> OTHERS <<
* emoji art - because why not             https://coolsymbol.com/lenny-faces-kawaii-dongers-emoticon-text-picture-text.html

***** Thanks everyone! ***** 
 */
