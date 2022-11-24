using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundation.Data
{
    public class GoodDonations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GoodDonationId { get; set; }
        public int NumberOfItems { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? Donor { get; set; }
        public int CatergoryId { get; set; }
        public virtual Catergory Catergory { get; set; }
    }
}
