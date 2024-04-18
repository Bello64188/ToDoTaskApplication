using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoTaskApplication.Context;
using ToDoTaskApplication.Models;

namespace ToDoTaskApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbAppContext _context;


        public HomeController(DbAppContext context)
        {
            _context = context;

        }

        public IActionResult Index(string id)
        {
            var filter = new Filters(id);
            var model = new ToDoViewModel
            {

                Filters = filter,
                Categories = _context.Categories.ToList(),
                Statuses = _context.Statuses.ToList(),
                DueFilterValue = Filters.DueFilterValues
            };
            //ViewBag.Filter = filter;
            //ViewBag.Categories = _context.Categories.ToList();
            //ViewBag.Statuses = _context.Statuses.ToList();
            //ViewBag.DueFilters = Filters.DueFilterValues;

            IQueryable<ToDo> query = _context.ToDos
                .Include(c => c.Category)
                .Include(s => s.Status);
            if (filter.HasCategory)
            {
                query = query.Where(t => t.CategoryId == filter.CategoryId);
            }
            if (filter.HasStatus)
            {
                query = query.Where(s => s.StatusId == filter.StatusId);
            }

            if (filter.HasDue)
            {
                var todey = DateTime.Today;
                if (filter.IsPast)

                    query = query.Where(t => t.DueDate < todey);

                else if (filter.IsFuture)

                    query = query.Where(t => t.DueDate > todey);


                else if (filter.IsToday)

                    query = query.Where(t => t.DueDate == todey);

            }
            model.Task = query.OrderBy(n => n.DueDate).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ToDoViewModel
            {
                Categories = _context.Categories.ToList(),
                Statuses = _context.Statuses.ToList()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ToDoViewModel model)
        {


            if (ModelState.IsValid)
            {
                _context.ToDos.Add(model.CurrentTask);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {

                model.Categories = _context.Categories.ToList();
                model.Statuses = _context.Statuses.ToList();

                return View(model);
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { Id = id });
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] string id, ToDo selected)
        {
            if (selected.StatusId == null)
            {
                _context.ToDos.Remove(selected);
            }

            else
            {
                string newString = selected.StatusId;
                selected = _context.ToDos.Find(selected.Id);
                selected.StatusId = newString;
                _context.ToDos.Update(selected);

            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { Id = id });
        }
    }
}
