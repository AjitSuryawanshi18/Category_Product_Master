using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Category_Product.Models
{
    [Table("tbl_Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}