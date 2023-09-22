namespace CreditAppVTP.Models
{
    public class Credit : BaseEntity
    {
        public Currency Valyuta { get; set; }
        public string? Purpose { get; set; }
        public decimal Price { get; set; }
        public int Month { get; set; }
        public int Interest { get; set; }

        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }


    public enum Currency
    {
        Azn = 0,
        TL = 1,
        Dollar = 2,
        Euro = 3
    }
}
