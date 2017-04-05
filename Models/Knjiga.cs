using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ISBNCover.Models
{
    public class Knjiga
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }

        
    }

    public class KnjigaDBContext : DbContext
    {
        public DbSet<Knjiga> Knjige { get; set; }
    }
}