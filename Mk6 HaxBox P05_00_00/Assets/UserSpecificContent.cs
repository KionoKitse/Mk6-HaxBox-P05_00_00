using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mk6_HaxBox_P05_00_00
{
    public class UserSpecificContent
    {
        //MySQL database settings
        public static string server = "localhost";	//Input your server ip addres default is localhost
        public static string database = "otterbase";	//Input your configure database name I'm using otterbase
        public static string user = "root";		//Input your configured username default is root
        public static string password = "";		//Input your configured password default is none

        public static string PathToMySQL = "C:\\Program Files\\MySQL\\MySQL Workbench 8.0 CE\\"; //TODO: Possible error point
    }
}