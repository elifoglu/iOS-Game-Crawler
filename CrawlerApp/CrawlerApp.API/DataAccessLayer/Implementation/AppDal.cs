using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrawlerApp.API.Data;
using CrawlerApp.API.DataAccessLayer.Abstraction;
using CrawlerApp.API.Models;

namespace CrawlerApp.API.DataAccessLayer.Implementation
{
    public class AppDal : IAppDal
    {
        private readonly DataContext _context;

        public AppDal(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAppsAsync(List<App> apps)
        {
            await _context.Apps.AddRangeAsync(apps);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<App> CheckIfPageAvailable(char letter, int pageIndex){
            List<App> apps = _context.Apps.Where(a => a.Name.ToLower().StartsWith(char.ToLower(letter)) && a.PageIndex == pageIndex).ToList();
            if(apps.Count == 0)
                return null;
            return apps;
        }
    }
}