using Proxy.CacheProxy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.CacheProxy.Manager
{
    public class YoutubeManager
    {
        private readonly IYoutubeOperations _youtube;

        public YoutubeManager(IYoutubeOperations youtube)
        {
            _youtube = youtube;
        }

        public void RenderHomepage()
        {
            Console.WriteLine("\nRendering homepage...");

            foreach (var homepageItem in _youtube.ShowHomepage())
            {
                Console.WriteLine($"Video with name: '{homepageItem.Name}' and description: '{homepageItem.Description}'");
            }
        }

        public void PlayVideo(int id)
        {
            Console.WriteLine("\nPlaying video...");

            var metadata = _youtube.GetVideoMetadata(id);
            Console.WriteLine($"Metadata loaded... Name: '{metadata.Name}' and description: '{metadata.Description}'");

            var video = _youtube.DownloadVideo(id);
            Console.WriteLine($"Streaming started... Content: {video.Content}");
        }
    }
}
