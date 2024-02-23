using Proxy.CacheProxy.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.CacheProxy.Common
{
    public interface IYoutubeOperations
    {
        VideoMetadata GetVideoMetadata(int id);
        Video DownloadVideo(int id);
        IEnumerable<VideoMetadata> ShowHomepage();
    }
}
