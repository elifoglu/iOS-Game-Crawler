using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlerApp.API.Models;

namespace CrawlerApp.API.DataAccessLayer.Abstraction
{
    public interface IAppDal
    {
         Task<bool> AddAppsAsync(List<App> apps);
         List<App> CheckIfPageAvailable(char letter, int pageIndex);

    }
}