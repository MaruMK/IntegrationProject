using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationProjectNMGM.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [MaxLength(2500)]
        public string ReviewDescription { get; set; }
        [Range(1,5)]
        [DefaultValue(3)]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int UserID { get; set; }
        public Product Product { get; set; }
    }
}