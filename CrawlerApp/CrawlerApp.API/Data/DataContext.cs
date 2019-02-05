using Microsoft.EntityFrameworkCore;
using CrawlerApp.API.Models;

namespace CrawlerApp.API.Data
{
    public class DataContext : DbContext
{
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<App> Apps { get; set; }
    
    }
}