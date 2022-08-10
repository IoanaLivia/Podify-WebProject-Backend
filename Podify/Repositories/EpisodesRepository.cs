using Podify.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Repositories
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private readonly AppDbContext db;

        public EpisodesRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Episode> GetEpisodesIQueriable()
        {
            var episode = db.Episodes;
            return episode;
        }

        public void Create(Episode episode)
        {
            db.Episodes.Add(episode);
            db.SaveChanges();
        }

        public void Update(Episode episode)
        {
            db.Episodes.Update(episode);
            db.SaveChanges();
        }

        public void Delete(Episode episode)
        {
            db.Episodes.Remove(episode);
            db.SaveChanges();
        }

        public IQueryable<EpisodeGuest> GetEpisodesGuests()
        {
            var episodesguests = db.EpisodeGuests.Include(x => x.Episode);

            return episodesguests;
        }
    }
}

