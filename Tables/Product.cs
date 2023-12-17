using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeApi.Tables
{
    public class Product
    {
        [Key]
        [Required]
        public string article { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [Column("max_discount_amount")]
        public int max_discount_amount { get; set; }

        [Required]
        [Column("manufacturer_id")]
        [ForeignKey("Manufacturer")]
        public int manufacturerId { get; set; }

        [Required]
        [Column("provider_id")]
        [ForeignKey("Provider")]
        public int providerId { get; set; }

        [Required]
        [Column("category_id")]
        [ForeignKey("Category")]
        public int categoryId { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        [Column("discount_amount")]
        public int discount_amount { get; set; }

        [Required]
        [Column("quantity_in_stock")]
        public int quantity_in_stock { get; set; }

        public string description { get; set; }
        
        public string photo {  get; set; }

        
        public Manufacturer manufacturer { get; set; }
        public Provider provider { get; set; }
        public Category category { get; set; }
    }
}
