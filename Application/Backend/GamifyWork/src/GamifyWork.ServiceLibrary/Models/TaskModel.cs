using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        //[DisplayFormat(DataFormatString = "{0:D10}")]
        public int? Points { get; set; }

        [Required]
        public bool Completed { get; set; }

        [Required]
        public bool Recurring { get; set; }

        [StringLength(45)]
        public string? RecurrenceType { get; set; }

        public int? RecurrenceInterval { get; set; }

        public DateTime? NextDueDate { get; set; }

        [Required]
        public int User_ID { get; set; }

        public DateTime? CalculateNextDueDate()
        {
            if (!Recurring)
            {
                return null;
            }

            if (RecurrenceType == "daily")
            {
                return NextDueDate?.AddDays(RecurrenceInterval ?? 1);
            }
            else if (RecurrenceType == "weekly")
            {
                return NextDueDate?.AddDays(7 * (RecurrenceInterval ?? 1));
            }
            else if (RecurrenceType == "monthly")
            {
                return NextDueDate?.AddMonths(RecurrenceInterval ?? 1);
            }

            throw new InvalidOperationException("Invalid recurrence type.");
        }
    }
}
