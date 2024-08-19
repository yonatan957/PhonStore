using Microsoft.EntityFrameworkCore;
using PhonStore.Models;

namespace PhonStore.Data
{
    public class PhoneStoreDB: DbContext
    {
        public DbSet<CosherPhone> cosherPhones {  get; set; }
        public DbSet<UnCosherPhone> unCosherPhones { get; set; }

        public PhoneStoreDB(DbContextOptions<PhoneStoreDB> options) : base
            (options)
        {
            Console.WriteLine("ReCreated DataBase " + Database.EnsureCreated());
        }
    }
}
