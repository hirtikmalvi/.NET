using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>()
        {
            new Task()
            {
                TaskId = 1,
                Title = "Cook Food",
                Deadline = new DateTime(2025, 06, 10),
                Priority = Priority.High,
                IsCompleted = false
            },
            new Task()
            {
                TaskId = 2,
                Title = "C#",
                Deadline = new DateTime(2025, 6, 9),
                Priority = Priority.Medium,
                IsCompleted = false
            },
            new Task()
            {
                TaskId = 3,
                Title = "Apply Job",
                Deadline = new DateTime(2025, 6, 8),
                Priority = Priority.Medium,
                IsCompleted = false
            }
        };

        public event EventHandler<Task> TaskDeadlineApproaching;

        public delegate void UpdateMarkTaskCompleted(int taskId);
        public void AddBook(Task task)
        {
            tasks.Add(task);
            Console.WriteLine("Task Added.");
        }

        public void MarkTaskCompleted(int taskId)
        {
            var foundTask = tasks.Find(t => t.TaskId == taskId);

            if (foundTask != null)
            {
                foundTask.IsCompleted = true;
            }
            Console.WriteLine("Task marked as completed.");
        }

        public void SortTasks(Func<Task, object> sortBy)
        {
            Console.WriteLine($"Sortby: {sortBy}");
            var sorted = tasks.OrderBy(sortBy).ToList();
            foreach (var task in sorted)
            {
                Console.WriteLine($"{task.TaskId}: {task.Title} - {task.Priority} - Due: {task.Deadline} - Completed: {task.IsCompleted}");
            }
        }

        public void CheckTaskDeadLines()
        {
            foreach (var task in tasks)
            {
                if (!task.IsCompleted && (task.Deadline - DateTime.Now).TotalHours <= 24)
                {
                TaskDeadlineApproaching?.Invoke(this, task);
                }
            }
        }

        public void FilterTasks(Func<Task, bool> filter)
        {
            var filteredTasks = tasks.Where(filter).ToList();
            Console.WriteLine($"Filter: {filter}");
            foreach (var task in filteredTasks)
            {
                Console.WriteLine($"{task.TaskId}: {task.Title} - {task.Priority} - Due: {task.Deadline} - Completed: {task.IsCompleted}");
            }
        }

        public void SearchTasksUsingKeywords(string keyword)
        {
            var foundTasks = tasks.FindAll(t => t.Title.Trim().ToLower().Contains(keyword)).ToList();

            Console.WriteLine("\nMatching Tasks:");
            foreach (var task in foundTasks)
            {
                Console.WriteLine($"- {task.Title} (Deadline: {task.Deadline.ToShortDateString()}, Priority: {task.Priority})");
            }
        }

        public void ViewAllTasks()
        {
            Console.WriteLine("All Tasks");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}: {task.Title} - {task.Priority} - Due: {task.Deadline} - Completed: {task.IsCompleted}");
            }
        }
    }
}
