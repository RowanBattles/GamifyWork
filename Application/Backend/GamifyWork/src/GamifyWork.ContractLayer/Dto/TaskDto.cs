﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ContractLayer.Dto
{
    public class TaskDto
    {
        public TaskDto(int task_ID, string title, string? description, int points, bool completed,
            bool recurring, string? recurrenceType, int? recurrenceInterval, DateTime? nextDueDate, Guid user)
        {
            Task_ID = task_ID;
            Title = title;
            Description = description;
            Points = points;
            Completed = completed;
            Recurring = recurring;
            RecurrenceType = recurrenceType;
            RecurrenceInterval = recurrenceInterval;
            NextDueDate = nextDueDate;
            User = user;
        }

        public int Task_ID { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int Points { get; private set; }
        public bool Completed { get; private set; }
        public bool Recurring { get; private set; }
        public string? RecurrenceType { get; private set; }
        public int? RecurrenceInterval { get; private set; }
        public DateTime? NextDueDate { get; private set; }
        public Guid User { get; private set; }
    }
}
