using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Models
{
    public class TaskModel
    {
        public int Task_ID { get; set; }
        public string Title { get; set;}
        public string Description { get; set;}
        public int Points { get; set;}
        public bool Completed { get; set; }
        public bool Recurring { get; set; }
        public string RecurrenceType { get; set; }
        public int RecurrenceInterval { get; set; }
        public DateTime NextDueDate { get; set; }
        public int User_ID { get; set; }

    }
}
