using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntegrationProjectNMGM.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}