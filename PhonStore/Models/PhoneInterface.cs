using System.ComponentModel.DataAnnotations;

namespace PhonStore.Models
{
    public interface PhoneInterface
    {
        [Key]
        public int Id { get; set; }
        public string Conpany { get; set; }
        public int price { get; set; }

        public int Quantity { get; set; }
    }
}
