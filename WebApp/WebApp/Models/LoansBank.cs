using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoansBank
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required, MaxLength(100)]
        public string Money { get; set; }
    }
}
