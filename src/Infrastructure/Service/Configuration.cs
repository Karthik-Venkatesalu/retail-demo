using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Service
{
    internal static class Configuration
    {
        public static string GetDBConnectionString()
        {
            // TODO: Fetch from secret manager
            return "Host=retail.ckdibq39pg0a.ap-south-1.rds.amazonaws.com;Port=5432;Username=postgres;Password=;Database=retail";
        }
    }
}
