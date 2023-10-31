using GamifyWork.ServiceLibrary.Models;
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
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => 
            dbContextOptionsBuilder.UseMySQL(_connectionString);
        public virtual DbSet<TaskModel> task { get; set; }
        public DbSet<RewardModel> reward { get; set; }
    }
}
