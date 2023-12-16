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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; private set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Points { get; set; }
        public bool Completed { get; set; }
        public bool Recurring { get; set; }
        public string? RecurrenceType { get; set; }
        public int? RecurrenceInterval { get; set; }
        public DateTime? NextDueDate { get; set; }
        public Guid User { get; set; }
    }
}
