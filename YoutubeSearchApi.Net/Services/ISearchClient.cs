using System.Threading.Tasks;

namespace YoutubeSearchApi.Net.Services
{
    public interface ISearchClient<T>
    {
        T Search(string query, int retry = 3);
        Task<T> SearchAsync(string query, int retry = 3);
    }
}
