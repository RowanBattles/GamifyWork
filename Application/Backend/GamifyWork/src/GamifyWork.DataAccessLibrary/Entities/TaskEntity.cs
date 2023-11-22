using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Entities
{
    public class TaskEntity
    {
        public TaskEntity(int task_ID, string title, string? description, int points, bool completed,
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int Points { get; private set; }
        public bool Completed { get; private set; }
        public bool Recurring { get; private set; }
        public string? RecurrenceType { get; private set; }
        public int? RecurrenceInterval { get; private set; }
        public DateTime? NextDueDate { get; private set; }
        public int User_ID { get; private set; }
    }
}
