using Proxy.CacheProxy;
using Proxy.CacheProxy.Manager;
using Proxy.CacheProxy.Proxy;
using Proxy.CacheProxy.ThirdParty;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Caching proxy example----");
            var youtubeService = new Youtube();
            var cachedYoutubeService = new CachedYoutube(youtubeService);
            var youtubeManager = new YoutubeManager(cachedYoutubeService);

            youtubeManager.PlayVideo(1);
            youtubeManager.PlayVideo(2);
            // Video 1 should be cached. Therefore, a request to the third party service shouldn't be issued.
            youtubeManager.PlayVideo(1);
        }
    }
}
