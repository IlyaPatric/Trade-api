using System.ComponentModel.DataAnnotations;

namespace TradeApi.Tables
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
