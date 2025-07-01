namespace Todo_List_P6.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool isCompleted {  get; set; }
    }
}
