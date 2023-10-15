using System;
using Microsoft.Extensions.Configuration;

namespace BaseProject.Persistence
{
    static class Configuration
    {
        public static string GetConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/BaseProject.API"));
                configurationManager.AddJsonFile("appsettings.json");
                configurationManager.AddJsonFile($"appsettings.Development.json");
                configurationManager.AddJsonFile($"appsettings.Production.json");

                string? connectionString = configurationManager.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string not found");
                }
                return connectionString;
            }
        }
    }
}

