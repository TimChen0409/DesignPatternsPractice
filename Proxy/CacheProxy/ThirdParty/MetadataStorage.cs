﻿using Proxy.CacheProxy.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.CacheProxy.ThirdParty
{
    public class MetadataStorage
    {
        private readonly Dictionary<int, VideoMetadata> _videos;

        public MetadataStorage()
        {
            _videos = new Dictionary<int, VideoMetadata>
        {
            { 1, new VideoMetadata { Id = 1, Name = "Video 1", Description = "Video 1 description", } },
            { 2, new VideoMetadata { Id = 2, Name = "Video 2", Description = "Video 2 description", } },
            { 3, new VideoMetadata { Id = 3, Name = "Video 3", Description = "Video 3 description", } },
        };
        }

        public IEnumerable<VideoMetadata> GetAll()
        {
            Console.WriteLine("Getting metadata for all videos from the metadata storage...");
            return _videos.Values;
        }

        public VideoMetadata GetById(int id)
        {
            Console.WriteLine($"Getting metadata for the video with ID: {id} from the metadata storage...");

            if (!_videos.TryGetValue(id, out var videoMetadata))
            {
                throw new ArgumentException($"ID: {id} is unknown to metadata storage.");
            }

            return videoMetadata;
        }
    }
}
