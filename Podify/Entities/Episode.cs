namespace Podify.Entities
{
    public class Episode
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Realeased { get; set; }

        public string PodcastId { get; set; } //FK Podcast
        public virtual Podcast Podcast { get; set; } //1-M
        public virtual ICollection<EpisodeGuest> EpisodeGuests { get; set; } //M-M 

    }
}
