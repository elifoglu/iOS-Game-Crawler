using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CrawlerApp.API.DataAccessLayer.Abstraction;
using CrawlerApp.API.DataAccessLayer.Implementation;
using CrawlerApp.API.Manager.Abstraction;
using CrawlerApp.API.Models;
using HtmlAgilityPack;

namespace CrawlerApp.API.Manager.Implementation
{
    public class CrawlManager : ICrawlManager
    {
        private readonly string constURL = "https://itunes.apple.com/us/genre/ios-games/id6014?mt=8";
        private readonly WebClient client;
        private readonly IAppDal _appDal;
        public CrawlManager(IAppDal appDal)
        {
            _appDal = appDal;
            client = new WebClient();
        }

        public List<App> StartCrawling(char letter, int pageIndex)
        {
            List<App> apps = _appDal.CheckIfPageAvailable(letter, pageIndex);
            if(apps != null)
                return apps;

            apps = new List<App>();
            
            string URL = constURL;
            URL += "&letter=" + letter;
            URL += "&page=" + pageIndex;

            string html = client.DownloadString(URL);
            //agility pack
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode specificNode = doc.GetElementbyId("selectedcontent"); //an element that only contains <ul> tags, restricts search area

            foreach (HtmlNode liNode in specificNode.Descendants("li"))
            {
                HtmlNode aNode = liNode.Descendants("a").ToList()[0];
                string appName = aNode.InnerHtml;
                string appURL = aNode.GetAttributeValue("href", "noURL");
                string imageURL = CrawlForAppImage(appURL);
                if(!imageURL.Contains("error"))
                {
                    App app = new App(appName, imageURL, appURL, pageIndex);
                    apps.Add(app);
                }
            }

            _appDal.AddAppsAsync(apps);
            return apps;
        }


        private string CrawlForAppImage(string appURL)
        {
            string html = client.DownloadString(appURL);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                HtmlNode specificNode = doc.GetElementbyId("ember-app"); //an element to restrict search area
                HtmlNode pictureNode = specificNode.Descendants("picture").ToList()[0];
                HtmlNode imageNode = pictureNode.Descendants("img").ToList()[0];
                string imageURL = imageNode.GetAttributeValue("src", "noURL");
                return imageURL;
            }
            catch (System.Exception)
            {
                return "error";
            }
        }

    }
}