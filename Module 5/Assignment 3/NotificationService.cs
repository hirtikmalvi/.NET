using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class NotificationService
    {
        public void HandleNotification(object sender, Task task)
        {
            Console.WriteLine($"\nReminder: Task '{task.Title}' is due within 24 hours!\n");
        }
    }
}
