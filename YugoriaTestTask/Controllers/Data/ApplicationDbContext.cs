using Microsoft.EntityFrameworkCore;
using YugoriaTestTask.Models;

namespace YugoriaTestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<KindAnimalModel> KindAnimals { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<RegionModel> Regions { get; set; }
        public DbSet<SkinColorModel> SkinColors {  get; set; }
    }
}
