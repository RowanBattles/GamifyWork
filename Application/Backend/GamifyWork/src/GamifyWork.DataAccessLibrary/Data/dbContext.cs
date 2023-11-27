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
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseMySQL(_connectionString);
        }

        public DbSet<TaskEntity> task { get; set; }
        public DbSet<RewardEntity> reward { get; set; }
    }
}
