using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace IntegrationProjectNMGM.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [MaxLength(2500)]
        public string ReviewDescription { get; set; }
        [Range(1,5)]
        [DefaultValue(3)]
        public string Rating { get; set; }
    }
}