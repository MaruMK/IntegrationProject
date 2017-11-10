using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationProjectNMGM.Models
{
    //CREATED BY GABRIEL CHARLEBOIS
    //This class is used to store a product its Reviews.
    //It is used to pass from the Products controller into the Details view
    public class ProductAndReviews
    {
        public IEnumerable<Review> Reviews { get; set; }
        public Product CurrentProduct { get; set; }
    }
}