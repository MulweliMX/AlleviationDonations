using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundation.Data
{
    public class Catergory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CatergoryId { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<GoodDonations> Goods { get; set; }
    }
}
