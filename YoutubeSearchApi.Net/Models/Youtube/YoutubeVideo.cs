namespace YoutubeSearchApi.Net.Models.Youtube
{
    public class YoutubeVideo
    {
        public string Id { get; }
        public string Url { get; set; }
        public string Title { get; }
        public string ThumbnailUrl { get; }
        public string Duration { get; }
        public string Author { get; }

        public YoutubeVideo(string Id, string Uri, string Title, string ThumbnailUrl, string Duration, string Author)
        {
            this.Id = Id;
            this.Url = Uri;
            this.Title = Title;
            this.ThumbnailUrl = ThumbnailUrl;
            this.Duration = Duration;
            this.Author = Author;
        }

        public override string ToString()
        {
            return "YoutubeVideo{" +
                "Id='" + Id + '\'' +
                ", Url='" + Url + '\'' +
                ", Title='" + Title + '\'' +
                ", ThumbnailUrl='" + ThumbnailUrl + '\'' +
                ", Author='" + Author + '\'' +
                ", Duration='" + Duration + '\'' +
                '}';
        }
    }
}