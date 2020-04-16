using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompare.Models;

namespace PhoneCompare
{
    public class PhoneCompareContext : DbContext
    {
        public PhoneCompareContext(DbContextOptions<PhoneCompareContext> options)
            : base(options)
        { }

        public DbSet<Samsung> Samsung { get; set; }

        public DbSet<Apple> Apple { get; set; }

        public DbSet<Login> Login { get; set; }

        public DbSet<Huawei> Huawei { get; set; }

        public DbSet<Lenovo> Lenovo { get; set; }

        public DbSet<Xiaomi> Xiaomi { get; set; }
    }
}
