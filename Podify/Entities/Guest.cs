namespace Podify.Entities
{
    public class Guest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
            
        public virtual ICollection<EpisodeGuest> EpisodeGuests { get; set; } //M-M 
    }
}
