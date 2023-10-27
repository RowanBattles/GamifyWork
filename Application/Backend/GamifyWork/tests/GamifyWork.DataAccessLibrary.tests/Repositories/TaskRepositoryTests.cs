using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.DataAccessLibrary.Repositories;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace GamifyWork.DataAccessLibrary.Tests.Repositories
{
    public class TaskRepositoryTests
    {
        ITaskRepository _repository;

        [Fact]
        public void Test()
        {

        }

        private List<TaskModel> GenerateData(int count)
        {
            var faker = new Faker<TaskModel>()
                .RuleFor(t => t.Task_ID, f => f.Random.Int(1, 1000))
                .RuleFor(t => t.Title, f => f.Lorem.Sentence(3))
                .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
                .RuleFor(t => t.Points, f => f.Random.Int(1, 1000))
                .RuleFor(t => t.Completed, f => f.Random.Bool())
                .RuleFor(t => t.Recurring, f => f.Random.Bool())
                .RuleFor(t => t.RecurrenceType, f => f.PickRandom(new[] { "Daily", "Weekly", "Monthly" }))
                .RuleFor(t => t.RecurrenceInterval, f => f.Random.Int(1, 5))
                .RuleFor(t => t.NextDueDate, f => f.Date.Future())
                .RuleFor(t => t.User_ID, f => f.Random.Int(1, 1000));

            return faker.Generate(count);
        }
    }
}
