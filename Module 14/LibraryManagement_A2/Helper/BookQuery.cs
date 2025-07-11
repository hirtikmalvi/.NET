namespace LibraryManagement_A2.Helper
{
    public class BookQuery
    {
        public int pageSize { get; set; } = 10;
        public int pageNumber { get; set; } = 1;
        public string? sortBy { get; set; } = null;
        public string? order { get; set; }
    }
}
