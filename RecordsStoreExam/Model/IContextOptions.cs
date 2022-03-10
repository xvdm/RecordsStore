using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsStoreExam.Model
{
    internal interface IContextOptions
    {
        public static DbContextOptions<MusicStoreContext> Options;
        private static bool _isConfigured = false;
        public static void Configure()
        {
            if (_isConfigured == false)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("AppConfig.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");
                var optionsBuilder = new DbContextOptionsBuilder<MusicStoreContext>();
                Options = optionsBuilder.UseSqlServer(connectionString).Options;
                _isConfigured = true;
            }
        }
    }
}
