using Proxy.CacheProxy.Modal;
using Proxy.CacheProxy.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.CacheProxy.ThirdParty
{
    public class ContentStorage
    {
        private readonly Dictionary<int, Video> _videos;

        public ContentStorage()
        {
            _videos = new Dictionary<int, Video>
        {
            { 1, new Video { Id = 1, Content = "Video 1 content" } },
            { 2, new Video { Id = 2, Content = "Video 2 content" } },
            { 3, new Video { Id = 3, Content = "Video 3 content" } },
        };
        }

        public Video GetById(int id)
        {
            Console.WriteLine($"Getting content for the video with ID: {id} from the content storage...");

            if (!_videos.TryGetValue(id, out var video))
            {
                throw new ArgumentException($"ID: {id} is unknown to content storage.");
            }

            return video;
        }
    }
}
