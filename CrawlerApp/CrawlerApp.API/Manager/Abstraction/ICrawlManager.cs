using System.Collections.Generic;
using CrawlerApp.API.Models;

namespace CrawlerApp.API.Manager.Abstraction
{
    public interface ICrawlManager
    {
         List<App> StartCrawling(char letter, int page);
    }
}