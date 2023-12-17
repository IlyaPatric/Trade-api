namespace TradeApi.Dto
{
    public class ProductDto
    {
        public string article { get; set; }
        public string name { get; set; }
        public int max_discount_amount { get; set; }
        public string manufacturer { get; set; }
        public string provider { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public int discount_amount { get; set; }
        public int quantity_in_stock { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
    }
}
