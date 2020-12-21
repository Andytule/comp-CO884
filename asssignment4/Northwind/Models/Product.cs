using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public partial class Product
    { 
        [Display(Name = "Id")]
        public int productId { get; set; }
        [Display(Name = "Name")]
        public string productName { get; set; }
        [Display(Name = "Supplier Id")]
        public int supplierId { get; set; }
        [Display(Name = "Category")]
        public int categoryId { get; set; }
        [Display(Name = "Quantity Per Unit")]
        public string quantityPerUnit { get; set; }
        [Display(Name = "Unit Price")]
        public decimal unitPrice { get; set; }
        [Display(Name = "In Stock")]
        public int unitsInStock { get; set; }
        [Display(Name = "On Order")]
        public int unitsOnOrder { get; set; }
        [Display(Name = "Reorder Level")]
        public int reorderLevel { get; set; }
        [Display(Name = "Discontinued")]
        public bool discontinued { get; set; }
    }

}
