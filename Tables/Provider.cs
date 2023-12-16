using System.ComponentModel.DataAnnotations;

namespace TradeApi.Tables
{
    public class Provider
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
