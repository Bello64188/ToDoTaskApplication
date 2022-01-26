using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTaskApplication.Models
{
    public class ToDoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Please Enter Task Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = " Please Enter Task Due Date")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = " Please Enter Category")]
       
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = " Please Enter Status")]
        
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool OverDue =>
            Status?.ToString().ToLower() == "open" && DueDate < DateTime.Today;

    }
}
