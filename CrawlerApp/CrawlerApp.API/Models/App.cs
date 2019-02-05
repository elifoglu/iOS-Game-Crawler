namespace CrawlerApp.API.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string PageURL { get; set; }
        public int PageIndex { get; set; }

        public App(string name, string imageURL, string pageURL, int pageIndex)
        {
            this.Name = name;
            this.ImageURL = imageURL;
            this.PageURL = pageURL;
            this.PageIndex = pageIndex;
        }
    }
}