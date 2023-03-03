using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

namespace PlaceApi.Db
{
    public class PlaceDbContext : DbContext
    {
        public PlaceDbContext(DbContextOptions<PlaceDbContext> options)  : base(options)
        {

        }
        public DbSet<Place> Places { get; set; }
    }

}
