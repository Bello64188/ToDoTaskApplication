using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTaskApplication.Models
{
    public class ToDoViewModel
    {

        public ToDoViewModel()
        {
            CurrentTask = new ToDo();
        }
        public Filters Filters { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Status> Statuses { get; set; }
        public IList<ToDo> Task { get; set; }
        public IDictionary<string, string> DueFilterValue { get; set; }

        public ToDo CurrentTask { get; set; }
    }
}
