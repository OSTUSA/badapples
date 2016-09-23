using System.ComponentModel.DataAnnotations;

namespace CrossSiteRequestForgeryApple.Models
{
    public class BankAccountViewModel
    {
        public decimal CurrentBalance { get; set; }

        [Required]
        public decimal? TransferAmount { get; set; }
    }
}