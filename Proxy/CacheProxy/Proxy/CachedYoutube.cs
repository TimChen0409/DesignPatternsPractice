using Proxy.CacheProxy.Common;
using Proxy.CacheProxy.Modal;
using Proxy.CacheProxy.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.CacheProxy.Proxy
{
    public class CachedYoutube : IYoutubeOperations
    {
        private readonly Youtube _youtubeService;
        private readonly Dictionary<int, Video> _contentCache;
        private readonly Dictionary<int, VideoMetadata> _metadataCache;

        public CachedYoutube(Youtube youtubeService)
        {
            _youtubeService = youtubeService;

            _contentCache = new Dictionary<int, Video>();
            _metadataCache = new Dictionary<int, VideoMetadata>();
        }

        public Video DownloadVideo(int id)
        {
            if (!_contentCache.TryGetValue(id, out var video))
            {
                video = _youtubeService.DownloadVideo(id);
                _contentCache.Add(video.Id, video);
            }

            return video;
        }

        public VideoMetadata GetVideoMetadata(int id)
        {
            if (!_metadataCache.TryGetValue(id, out var metadata))
            {
                metadata = _youtubeService.GetVideoMetadata(id);
                _metadataCache.Add(metadata.Id, metadata);
            }

            return metadata;
        }

        public IEnumerable<VideoMetadata> ShowHomepage()
        {
            // Naive logic - prepare the homepage using only cached data.
            IEnumerable<VideoMetadata> metadataForHomepage = _metadataCache.Values;

            if (!metadataForHomepage.Any())
            {
                // Nothing is cached on our side yet.
                // Send a network request to the Youtube in order to get enough information for showing the homepage.
                metadataForHomepage = _youtubeService.ShowHomepage();
                foreach (var videoMetadata in metadataForHomepage)
                {
                    _metadataCache.Add(videoMetadata.Id, videoMetadata);
                }
            }

            return metadataForHomepage;
        }
    }
}
