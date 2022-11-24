using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundation.Data
{
    public class MoneyDonations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MonetaryDonationId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? DonorName { get; set; }
    }
}
