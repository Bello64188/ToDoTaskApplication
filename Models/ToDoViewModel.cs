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
        public IList<Category> Categories { get; set; } = new List<Category>() {
            new Category {  CategoryId="work", Name="Work" },
            new Category { CategoryId = "home", Name = "Home" },
            new Category { CategoryId = "ex", Name = "Excercise" },
            new Category { CategoryId = "shop", Name = "Shopping" },
            new Category { CategoryId = "call", Name = "Contact" } };

        public IList<Status> Statuses { get; set; }
        public IList<ToDo> Task { get; set; }
        public IDictionary<string, string> DueFilterValue { get; set; }

        public ToDo CurrentTask { get; set; }
    }
}
