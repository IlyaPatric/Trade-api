using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeApi.Tables
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int max_discount_amount { get; set; }

        public int manufacturer_id { get; set; }

        public int provider_id {  get; set; }

        public int category_id {  get; set; }

        public int price { get; set; }

        public int discount_amount { get; set; }

        public int quantity_in_stock { get; set; }

        public string description { get; set; }

        public string photo {  get; set; }

        //[ForeignKey("id")]
        public Manufacturer Mnufacturer { get; set; }

        //[ForeignKey("id")]
        public Provider Provider { get; set; }

        //[ForeignKey("id")]
        public Category Category { get; set; }
    }
}
