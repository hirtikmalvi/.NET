using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public enum Priority
    {
        Low, Medium, High
    }
    public class Task
    {
        public int TaskId {  get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }

        public Priority Priority { get; set; }

        public bool IsCompleted {  get; set; }
    }
}
