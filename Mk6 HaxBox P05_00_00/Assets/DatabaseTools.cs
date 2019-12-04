using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;   //MySQL
using System.Diagnostics;       //ProcessStartInfo
using System.IO;                //StreamWriter
using Windows.Storage;          //StorageFile

/*
 * public DatabaseTools()
 * private void Initialize()
 * private bool OpenConnection()
 * private bool CloseConnection()
 * public void TestConnection()
 * public void GenCmd(string query) >>> Will be changed
 * public bool CheckDatabase()
 * public async void BackupAsync()
 * public async void RestoreBackupAsync()
 * public async void LoadSampleDatabaseAsync()
*/
namespace Mk6_HaxBox_P05_00_00
{
    class DatabaseTools
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string BackupFolderName;
        private string BackupName;
        private string PathToMySQL;
        
        //Constructor
        public DatabaseTools()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //Get the database settings
            server = UserSpecificContent.server;
            database = UserSpecificContent.database;
            uid = UserSpecificContent.user;
            password = UserSpecificContent.password;

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString); 
            BackupFolderName = "MySQL Backup";
            BackupName = "DatabaseBackup.sql";
            PathToMySQL = UserSpecificContent.PathToMySQL;
        }

        //open connection to database
        private bool OpenConnection()
        {

            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //Error management
                switch (ex.Number)
                {
                    case 0:
                        GenTools.ShowMessageAsync("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        GenTools.ShowMessageAsync("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                GenTools.ShowMessageAsync(ex.Message);
                return false;
            }
        }

        //Test connection
        public void TestConnection()
        {
            if (this.OpenConnection() == true)
            {
                GenTools.ShowMessageAsync("Connection Opened");
                this.CloseConnection();
                GenTools.ShowMessageAsync("Connection Closed");
            }
        }

        //General Execute Query
        public void GenCmd(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Check if database exists
        public bool CheckDatabase()
        {
            if (this.OpenConnection() == true)
            {
                //Create command and execute
                string query = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" + database + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                var result = cmd.ExecuteScalar();
                this.CloseConnection();

                //Check results
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Saves the backup to the application data 
        public async void BackupAsync()
        {
            try
            {
                //Check if the database folder exists
                bool FolderExist = await GenTools.FolderExistAsync(BackupFolderName);
                if (!FolderExist)
                {
                    //Create the back up folder
                    await GenTools.CreateFolderAsync(BackupFolderName);
                }
                //Check if there is a backup file already present
                bool FileExist = await GenTools.FileExistAsync(BackupName, BackupFolderName);
                if (FileExist)
                {
                    //Delete the file so a new one can be made
                    await GenTools.DeleteFileAsync(BackupName, BackupFolderName);
                }
                //Create the file
                await GenTools.CreateFileAsync(BackupName, BackupFolderName);
                string FilePath = await GenTools.GetFilePathAsync(BackupName, BackupFolderName);

                //Start the mysqldump.exe program 
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = $"{PathToMySQL}mysqldump.exe";        
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;
                Process process = Process.Start(psi);

                //Write mysqldump output to file
                StreamWriter file = new StreamWriter(FilePath);
                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
                GenTools.ShowMessageAsync("(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧ Database backed up");
            }
            catch
            {
                GenTools.ShowMessageAsync("(╯°□°）╯︵ ┻━┻ Unable to perform backup");
            }
        }

        //Restore a backup file from the application data
        public async void RestoreBackupAsync()
        {
            try
            {
                //Check if there is a backup file present
                bool FileExist = await GenTools.FileExistAsync(BackupName, BackupFolderName);
                if (FileExist)
                {
                    //Open the file and read the data
                    string FilePath = await GenTools.GetFilePathAsync(BackupName, BackupFolderName);
                    StreamReader BackupFile = new StreamReader(FilePath);
                    string FileInput = BackupFile.ReadToEnd();
                    BackupFile.Close();

                    //Open the MySQL application
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = $"{PathToMySQL}mysql.exe";
                    psi.RedirectStandardInput = true;
                    psi.RedirectStandardOutput = false;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                    psi.UseShellExecute = false;

                    //Input the data from the backup into MySQL
                    Process process = Process.Start(psi);
                    process.StandardInput.WriteLine(FileInput);
                    process.StandardInput.Close();
                    process.WaitForExit();
                    process.Close();

                    GenTools.ShowMessageAsync("(ﾉ^ω^)ﾉﾟ Database Restored");
                }
                else
                {
                    GenTools.ShowMessageAsync("^(*･｡･)ﾉ Can't find backup file");
                }
            }
            catch
            {
                GenTools.ShowMessageAsync("(:ㄏ■ Д ■ :)ㄏ Unable to Restore");
            }
        }

        //Load sample database
        public async void LoadSampleDatabaseAsync()
        {
            try
            {
                //Check if the folder exists
                bool FolderExist = await GenTools.FolderExistAsync(BackupFolderName);
                if (!FolderExist)
                {
                    //Create the folder
                    await GenTools.CreateFolderAsync(BackupFolderName);
                }

                //Check if the sample database already exists in application data
                bool FileExist = await GenTools.FileExistAsync("SampleDatabase.sql", BackupFolderName);
                if (!FileExist)
                {
                    //Get the sample database from the Assets folder
                    var storagefile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/SampleDatabase.sql"));

                    //Set working folder
                    StorageFolder WorkingFolder = ApplicationData.Current.LocalFolder;
                    WorkingFolder = await WorkingFolder.GetFolderAsync(BackupFolderName);

                    //Copy database to the Backup folder
                    await storagefile.CopyAsync(WorkingFolder);
                }
                //Open the file and read the data
                string FilePath = await GenTools.GetFilePathAsync("SampleDatabase.sql", BackupFolderName);
                StreamReader BackupFile = new StreamReader(FilePath);
                string FileInput = BackupFile.ReadToEnd();
                BackupFile.Close();

                //Open the MySQL application
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = $"{PathToMySQL}mysql.exe";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                //Input the data from the backup into MySQL
                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(FileInput);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();

                GenTools.ShowMessageAsync("(～￣▽￣)～ Sample database loaded");
            }
            catch
            {
                GenTools.ShowMessageAsync("｡゜(｀Д´)゜｡ Some major issue");
            }
        }
    }
}
/*
***** ROLL THE CREDITS *****
* Implementing C# MySQL functions         https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
* Getting data from assets folder         https://stackoverflow.com/questions/44140057/copy-file-from-uwp-resources-to-local-folder
>> OTHERS <<
* emoji art - because why not             https://textfac.es/
* emoji art - because why not             https://coolsymbol.com/lenny-faces-kawaii-dongers-emoticon-text-picture-text.html

***** Thanks everyone! ***** 
 */