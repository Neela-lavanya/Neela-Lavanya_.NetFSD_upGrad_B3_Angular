using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class ConfigurationManager
    {
        private static ConfigurationManager instance;

        public string AppName { get; set; }

        private ConfigurationManager()
        {
            AppName = "MyApp";
        }

        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
                instance = new ConfigurationManager();

            return instance;
        }
    }
}
