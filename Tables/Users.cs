using System.ComponentModel.DataAnnotations;

namespace TradeApi.Tables
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string patronymic { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string user_role { get; set; }
    }
}
