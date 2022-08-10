using Podify.Entities;
using Podify.Models;
using Podify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public class GuestsManager : IGuestsManager
    {
        private readonly IGuestsRepository guestsRepository;

        public GuestsManager(IGuestsRepository guestsRepository)
        {
            this.guestsRepository = guestsRepository;
        }

        public List<Guest> GetGuests()
        {
            return guestsRepository.GetGuestsIQueriable().ToList();
        }

        public Guest GetGuestById(string id)
        {
            var guest = guestsRepository
                  .GetGuestsIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return guest;
        }

        public void Create(GuestCreationModel model)
        {
            var newGuest = new Guest
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Description = model.Description
            };

            guestsRepository.Create(newGuest);
        }
        public void Update(GuestCreationModel model)
        {
            var newGuest = GetGuestById(model.Id);
            newGuest.Id = model.Id;
            newGuest.Name = model.Name;
            newGuest.Surname = model.Surname;
            newGuest.Description = model.Description;

            guestsRepository.Update(newGuest);
        }

        public void Delete(string id)
        {
            var newGuest= GetGuestById(id);

            guestsRepository.Delete(newGuest);
        }

        public int GetNumberOfGuests()
        {
            var noguests = guestsRepository
                  .GetGuestsIQueriable().Count();
            return noguests;
        }

        //episoadele in care apare un guest
        public List<EpisodeGuest> GetGuestEpisodes(string id)
        {
            var guestsepisodes = guestsRepository.GetGuestsEpisodes().ToList();
            var guestepisodes = guestsepisodes.Where(x => x.GuestId == id).ToList();
            return guestepisodes;
        }

        public List<Guest> GetGuestsOrderedByDescription()
        {
            var guests = GetGuests()
               .OrderBy(x => x.Description)
               .ToList();
            return guests;
        }

        public List<TotalNoGuests> GetNumberOfGuestTypes()
        {
            var notypes = guestsRepository
                  .GetGuestsIQueriable()
                  .GroupBy(x => x.Description,
                  (k, c) => new TotalNoGuests()
                  {
                      Title = k,
                      Number = c.Count()
                  })
                  .ToList();
            return notypes;
        }

    }
}

