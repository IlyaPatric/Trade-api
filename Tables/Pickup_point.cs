using System.ComponentModel.DataAnnotations;

namespace TradeApi.Tables
{
    public class Pickup_point
    {
        [Key]
        public int id { get; set; }
        public string index_city { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int house_number {  get; set; }
    }
}
