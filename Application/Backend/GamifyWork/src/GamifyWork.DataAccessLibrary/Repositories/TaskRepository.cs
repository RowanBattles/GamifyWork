using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;
        public TaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            // EntityFramework
            return new List<TaskModel>();
        }
    }
}
