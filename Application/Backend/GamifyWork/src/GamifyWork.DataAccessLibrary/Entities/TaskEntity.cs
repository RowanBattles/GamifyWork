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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; private set; }

        [Required]
        [StringLength(60)]
        public string Title { get; private set; }

        [StringLength(255)]
        public string? Description { get; private set; }

        [Required]
        public int Points { get; private set; }

        [Required]
        public bool Completed { get; private set; }

        [Required]
        public bool Recurring { get; private set; }

        public string? RecurrenceType { get; private set; }

        public int? RecurrenceInterval { get; private set; }

        public DateTime? NextDueDate { get; private set; }

        [Required]
        public int User_ID { get; private set; }
    }
}
