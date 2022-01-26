using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTaskApplication.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="* Please Enter Task Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "* Please Enter  Due Date")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "* Please Select Category")]
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "* Please Select Status")]
        [ForeignKey("Status")]
        public string StatusId { get; set; }
        public Status   Status  { get; set; }
        public bool OverDue =>
            StatusId?.ToLower() == "open" && DueDate < DateTime.Today;

    }
}
