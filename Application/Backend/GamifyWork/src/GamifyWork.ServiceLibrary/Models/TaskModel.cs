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
    }
}
