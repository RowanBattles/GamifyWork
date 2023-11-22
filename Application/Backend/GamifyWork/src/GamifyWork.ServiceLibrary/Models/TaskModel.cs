﻿using GamifyWork.ServiceLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Models
{
    public class TaskModel 
    {
        public TaskModel(int task_ID, string title, string? description, int? points, bool completed, 
            bool recurring, string? recurrenceType, int? recurrenceInterval, DateTime? nextDueDate, int user_ID)
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
            User_ID = user_ID;
        }
        public int Task_ID { get; private set; }
        [Required]
        [StringLength(60)]
        public string Title { get; private set; }
        [StringLength(255)]
        public string? Description { get; private set; }
        public int? Points { get; private set; }
        public bool Completed { get; private set; }
        public bool Recurring { get; private set; }
        public string? RecurrenceType { get; private set; }
        public int? RecurrenceInterval { get; private set; }
        public DateTime? NextDueDate { get; private set; }
        public int User_ID { get; private set; }

        public DateTime? CalculateNextDueDate()
        {
            if (Recurring)
            {
                if (RecurrenceType == "Daily")
                {
                    return NextDueDate?.AddDays(RecurrenceInterval ?? 1);
                }
                else if (RecurrenceType == "Weekly")
                {
                    return NextDueDate?.AddDays(7 * (RecurrenceInterval ?? 1));
                }
                else if (RecurrenceType == "Monthly")
                {
                    return NextDueDate?.AddMonths(RecurrenceInterval ?? 1);
                }
                else
                {
                    throw new InvalidOperationException("RecurrenceType must be Daily, Weekly or Monthly");
                }
            }
            else
            {
                return null;
            }
        }

        public void SetPoints()
        {
            Random random = new();
            this.Points = random.Next(10, 200);
        }

        public void CheckValidation()
        {
            if(Recurring)
            {
                if(RecurrenceType != "Daily" && RecurrenceType != "Weekly" && RecurrenceType != "Monthly")
                {
                    throw new TaskException("RecurrenceType must be Daily, Weekly or Monthly", (int)HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
