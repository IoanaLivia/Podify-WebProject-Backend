using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Repositories
{
    public class PodcastsRepository : IPodcastsRepository
    {
        private readonly AppDbContext db;

        public PodcastsRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Podcast> GetPodcastsIQueriable()
        {
            var podcast = db.Podcasts;
            return podcast;
        }

        public void Create(Podcast podcast)
        {
            db.Podcasts.Add(podcast);
            db.SaveChanges();
        }

        public void Update(Podcast podcast)
        {
            db.Podcasts.Update(podcast);
            db.SaveChanges();
        }

        public void Delete(Podcast podcast)
        {
            db.Podcasts.Remove(podcast);
            db.SaveChanges();
        }

    }
}

