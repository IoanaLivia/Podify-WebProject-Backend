using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Models
{
    public class EpisodeCreationModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Realeased { get; set; }
        public string PodcastId { get; set; } //FK Podcast

    }
}
