namespace jobwatcher.Models
{
    public class Job
    {
        public string Status { get; set;  }
        public string Text{ get; set; }
        public int Id { get; set; }
        public string Timestamp { get; set; }
    }
}