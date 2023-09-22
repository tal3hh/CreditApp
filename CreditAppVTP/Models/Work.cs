namespace CreditAppVTP.Models
{
    public class Work : BaseEntity
    {
        public string? WorkName { get; set; }
        public string? Region { get; set; }
        public string? Adress { get; set; }
        public int Salary { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }

        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
