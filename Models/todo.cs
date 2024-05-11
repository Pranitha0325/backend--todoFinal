namespace backend.Models
{
    public class todo
    {
        public Guid Id { get; set; }
        public  String Title { get; set; }
        public DateTime  CreatedAt { get; set; }
        public  bool IsCompleted { get; set; }

    }
}
