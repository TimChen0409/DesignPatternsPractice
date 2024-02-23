using Proxy.CacheProxy.Common;
using Proxy.CacheProxy.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.CacheProxy.ThirdParty
{
    public class Youtube : IYoutubeOperations
    {
        private readonly ContentStorage _contentStorage = new();
        private readonly MetadataStorage _metadataStorage = new();

        public Video DownloadVideo(int id) => _contentStorage.GetById(id);

        public VideoMetadata GetVideoMetadata(int id) => _metadataStorage.GetById(id);

        public IEnumerable<VideoMetadata> ShowHomepage() => _metadataStorage.GetAll();
    }
}
