namespace YoutubeSearchApi.Net.Models.Google;

public class GoogleResult
{
    public string Url { get; }

    public string Title { get; }

    public string Query { get; }

    public string Description { get; }

    public GoogleResult(string url, string title, string query, string description)
    {
        Url = url;
        Title = title;
        Query = query;
        Description = description;
    }

    public override string ToString()
    {
        return "GoogleSearchResult{" +
            "\nUrl='" + Url + '\'' + ",\n" +
            "Title='" + Title + '\'' + ",\n" +
            "Description='" + Description + '\'' + ",\n" +
            '}';
    }
}
