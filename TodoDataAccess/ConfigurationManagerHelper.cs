using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TodoDataAccess
{
    public static class ConfigurationManagerHelper
    {
        public static string DBConn(string name)
        {
          return ConfigurationManager.ConnectionStrings[name].ConnectionString;


        }

    }
}
