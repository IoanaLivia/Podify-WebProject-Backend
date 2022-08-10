namespace Podify.Entities
{
    public class EpisodeGuest
    {
        public string EpisodeId { get; set; }
        public string GuestId { get; set; }

        public virtual Episode Episode { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
