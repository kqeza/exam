using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("article")]
        public string Article { get; set; }
        [Column("odate")]
        public DateTime Odate { get; set; }
        [Column("ddate")]
        public DateTime Ddate { get; set; }
        [Column("addressId")]
        public int AddressId { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        [Column("code")]
        public int Code { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
