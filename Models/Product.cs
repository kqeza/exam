using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("article")]
        public string Article { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("unit")]
        public string Unit { get; set; }
        [Column ("price")]
        public decimal Price { get; set; }
        [Column("supplier")]
        public string Supplier { get; set; }
        [Column("manufacturer")]
        public string Manufacturer { get; set; }
        [Column("category")]
        public string Category { get; set; }
        [Column("discount")]
        public int Discount { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image")]
        public string Image { get; set; }
    }
}
