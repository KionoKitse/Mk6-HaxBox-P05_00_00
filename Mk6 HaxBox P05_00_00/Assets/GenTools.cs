using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;        //MessageDialog
using Windows.Storage;          //StorageFolder
/*
>> GENERAL <<
 * public static async void ShowMessageAsync(string mytext)
>> FOLDER TOOLS <<
 * public static async Task<bool> FolderExistAsync(string folderName)
 * public static async Task CreateFolderAsync(string folderName)
 * public static async Task<bool> FileExistAsync(string filename, string folderName)
 * public static async Task DeleteFileAsync(string fileName, string folderName)
 * public static async Task CreateFileAsync(string fileName, string folderName)
 * public static async Task<string> GetFilePathAsync(string fileName, string folderName)
*/
namespace Mk6_HaxBox_P05_00_00
{
    class GenTools
    {
        // >>> GENERAL <<<
        //To show a message
        public static async void ShowMessageAsync(string mytext)
        {
            var dialog = new MessageDialog(mytext);
            await dialog.ShowAsync();
        }
// >>> FOLDER TOOLS <<<
        //Check if a folder exists within application data 
        public static async Task<bool> FolderExistAsync(string folderName)
        {
            StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
            var Result = await WorkingFolder.TryGetItemAsync(folderName);

            if (Result != null)
                return true;
            else
                return false;
        }
        //Create a folder within the application data
        public static async Task CreateFolderAsync(string folderName)
        {
            StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
            await WorkingFolder.CreateFolderAsync(folderName);
        }
        //Check if a file exists within a folder in application data
        public static async Task<bool> FileExistAsync(string filename, string folderName)
        {

            StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
            WorkingFolder = await WorkingFolder.GetFolderAsync(folderName);
            var Result = await WorkingFolder.TryGetItemAsync(filename);
            if (Result != null)
                return true;
            else
                return false;
        }
        //Delete a file within a specific folder in application data
        public static async Task DeleteFileAsync(string fileName, string folderName)
        {
            StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
            WorkingFolder = await WorkingFolder.GetFolderAsync(folderName);
            StorageFile WorkingFile = await WorkingFolder.GetFileAsync(fileName);
            await WorkingFile.DeleteAsync();
        }
        //Create a file within a specific folder in application data
        public static async Task CreateFileAsync(string fileName, string folderName)
        {
            StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
            WorkingFolder = await WorkingFolder.GetFolderAsync(folderName);
            StorageFile WorkingFile = await WorkingFolder.CreateFileAsync(fileName);
        }
        //Get the file path of a file inside a folder within application data
        public static async Task<string> GetFilePathAsync(string fileName, string folderName)
        {
            StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
            WorkingFolder = await WorkingFolder.GetFolderAsync(folderName);
            StorageFile WorkingFile = await WorkingFolder.GetFileAsync(fileName);
            string Result = WorkingFile.Path;
            return Result;
        }
    }
}
/*
***** ROLL THE CREDITS *****
>> FOLDER TOOLS <<
* File Permissions for UWP                https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions
* Application Data tools                  https://github.com/Bulo582/Fiszki/blob/e7533cf097f61f57e79c94500d522082be4bdb14/Fiszki/Fiszki.UWP/SaveAndLoad_UWP.cs

***** Thanks everyone! ***** 
 */
