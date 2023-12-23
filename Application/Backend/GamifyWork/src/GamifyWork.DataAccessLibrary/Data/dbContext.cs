using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Data
{
    public class dbContext : DbContext
    {
        private readonly string _connectionString;
        public dbContext(IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionstring))
            {
                throw new ArgumentNullException("Connection string is null");
            }
            _connectionString = connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseMySQL(_connectionString);
        }

        public DbSet<TaskEntity> task { get; set; }
        public DbSet<RewardEntity> reward { get; set; }
        public DbSet<UserEntity> user { get; set; }
    }
}
