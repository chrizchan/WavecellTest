using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Wavecell.Configuration
{
    public class SettingManager
    {
        public static string Account
        {
            get { return ConfigurationManager.AppSettings["Account"]; }
        }

        public static string SubAccount
        {
            get { return ConfigurationManager.AppSettings["SubAccount"]; }
        }

        public static string AccountPassword
        {
            get { return ConfigurationManager.AppSettings["AccountPassword"]; }
        }

        public static string UMID
        {
            get { return ConfigurationManager.AppSettings["UMID"]; }
        }

        public static string ScheduleDateTime
        {
            get { return ConfigurationManager.AppSettings["ScheduleDateTime"]; }
        }

        public static string Source
        {
            get { return ConfigurationManager.AppSettings["Source"]; }
        }

        public static string Encoding
        {
            get { return ConfigurationManager.AppSettings["Encoding"]; }
        }


    }
}