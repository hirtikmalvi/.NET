using Assignment_3;

internal class Program
{
    public void TaskManagerSystem()
    {
        TaskManager taskManager = new TaskManager();

        var updateMarkTaskCompleted = new TaskManager.UpdateMarkTaskCompleted(taskManager.MarkTaskCompleted);

        var notifier = new NotificationService();

        bool isEnd = false;
        while (!isEnd)
        {
            Console.WriteLine($"Choice: \n1. Add New Task\n2. Mark a Task as Completed\n3. View All Tasks\n4. Filter Tasks By Custom Criteria\n5. Trigger Deadline Notifications\n6. Sort Tasks\n7. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter ID: ");
                    int taskId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Title: ");
                    string title = Console.ReadLine();

                    Console.WriteLine("Enter Date (yyyy-mm-dd): ");
                    DateTime deadline = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Enter Priority (Low, Medium, High): ");

                    Priority priority = (Priority)Enum.Parse(typeof(Priority), Console.ReadLine());

                    var task = new Assignment_3.Task();
                    task.TaskId = taskId;
                    task.Title = title;
                    task.Deadline = deadline;
                    task.IsCompleted = false;
                    
                    taskManager.AddBook(task);
                    break;
                case 2:
                    Console.WriteLine("Enter Task ID: ");
                    taskId = Convert.ToInt32(Console.ReadLine());
                    taskManager.MarkTaskCompleted(taskId);
                    break;
                case 3:
                    taskManager.ViewAllTasks();
                    break;
                case 4:
                    Console.WriteLine("\n1. High Priority\n2. Incomplete Tasks\n3. All Tasks Due withing a week");
                    int c = Convert.ToInt32(Console.ReadLine());
                    if (c == 1)
                    {
                        taskManager.FilterTasks(t => t.Priority == Priority.High);
                    }
                    else if (c == 2)
                    {
                        taskManager.FilterTasks(t => !t.IsCompleted);
                    }
                    else if (c == 3)
                    {
                        taskManager.FilterTasks(t => t.Deadline <= DateTime.Now.AddDays(7));
                    }
                    break;
                 case 5:
                    taskManager.TaskDeadlineApproaching += notifier.HandleNotification;
                    taskManager.CheckTaskDeadLines();
                    break;
                case 6:
                    Console.WriteLine("\n1. Sort By Deadline\n2. Sort By Priority\n3. Sort By Title Length");

                    int sc = Convert.ToInt32(Console.ReadLine());

                    if (sc == 1)
                    {
                        taskManager.SortTasks(t => t.Deadline); 
                    }
                    else if (sc == 2)
                    {
                        taskManager.SortTasks(t => t.Priority);
                    }
                    else if (sc == 3)
                    {
                        taskManager.SortTasks(t => t.Title.Length);
                    }
                    break;
                case 7:
                    return;
            }
        }
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        program.TaskManagerSystem();
    }
}