using System.ComponentModel.DataAnnotations;

namespace CreditAppVTP.Models
{
    public class AppUser : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Fathername { get; set; }
        public string? Location { get; set; }
        public string? Seria { get; set; }
        public string? FIN { get; set; }
        public string? RegisAdress { get; set; }
        public DateTime Date { get; set; }
        public int Mobil { get; set; }
        public int HomeNum { get; set; }

        public List<Credit>? Credits { get; set; }
        public Work? Work { get; set; }
    }
}
