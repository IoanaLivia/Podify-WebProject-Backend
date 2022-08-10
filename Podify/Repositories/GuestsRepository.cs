using Podify.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Repositories
{
    public class GuestsRepository : IGuestsRepository
    {
        private readonly AppDbContext db;

        public GuestsRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Guest> GetGuestsIQueriable()
        {
            var guest = db.Guests;
            return guest;
        }

        public void Create(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
        }

        public void Update(Guest guest)
        {
            db.Guests.Update(guest);
            db.SaveChanges();
        }

        public void Delete(Guest guest)
        {
            db.Guests.Remove(guest);
            db.SaveChanges();
        }

        public IQueryable<EpisodeGuest> GetGuestsEpisodes()
        {
            var guestsepisodes = db.EpisodeGuests.Include(x => x.Guest);
            return guestsepisodes;
        }

     

    }

}

