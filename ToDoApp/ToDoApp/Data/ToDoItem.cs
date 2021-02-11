using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public class ToDoItem
    {
        [Required]
        [Display(Name = "Task")]
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]

        public DateTime DueDate { get; set; }

    }
}
