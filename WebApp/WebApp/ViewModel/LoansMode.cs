using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class LoansMode
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [Required, StringLength(100)]
        public string Money { get; set; }
    }
}
