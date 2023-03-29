using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Category_Product.Models
{
    [Table("tbl_Category")]
    public class Category
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}