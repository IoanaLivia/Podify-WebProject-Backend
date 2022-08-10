using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Podify.Auth;
using Podify.Entities;

namespace Podify.Entities
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeGuest> EpisodeGuests { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<PodcastHost> PodcastHosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(builder);

            //One to One : Podcast - PodcastHost
            builder.Entity<Podcast>()
                .HasOne(podcast => podcast.PodcastHost)
                .WithOne(host => host.Podcast);


            //One to Many : Podcast - Episode
            builder.Entity<Podcast>()
                .HasMany(podcast => podcast.Episodes)
                .WithOne(episode => episode.Podcast);

            //Many To Many : Episode - Guest 
            builder.Entity<EpisodeGuest>().HasKey(episodeguest => new { episodeguest.EpisodeId, episodeguest.GuestId });

            builder.Entity<EpisodeGuest>()
                .HasOne(episodeguest => episodeguest.Episode)
                .WithMany(episode => episode.EpisodeGuests)
                .HasForeignKey(episodeguest => episodeguest.EpisodeId);

            builder.Entity<EpisodeGuest>()
                .HasOne(episodeguest => episodeguest.Guest)
                .WithMany(guest => guest.EpisodeGuests)
                .HasForeignKey(episodeguest => episodeguest.GuestId);
        }
    }
   // }
    
}

