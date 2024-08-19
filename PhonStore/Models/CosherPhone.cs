namespace PhonStore.Models
{
    public class CosherPhone : PhoneInterface
    {
        public int Id { get; set; }
        public string Conpany { get; set; }
        public int price { get; set; }
        public int Quantity { get; set; }
        public string cashrutType { get; set; }
    }
}
