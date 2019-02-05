using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HtmlAgilityPack;
using CrawlerApp.API.Manager.Abstraction;
using CrawlerApp.API.Models;

namespace CrawlerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrawlController : ControllerBase
    {
        private readonly ICrawlManager _crawlManager;

        public CrawlController(ICrawlManager crawlManager)
        {
            _crawlManager = crawlManager;
        }

        [HttpGet]
        public IActionResult GetAppInfos(char letter, int pageIndex)
        {
            if(pageIndex < 1 || pageIndex > 15 || !Char.IsLetter(letter))
                return Ok(null);
            
            List<App> result = _crawlManager.StartCrawling(letter, pageIndex);
            return Ok(result);
        }

    }
}
