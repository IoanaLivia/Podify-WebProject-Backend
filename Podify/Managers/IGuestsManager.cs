using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public interface IGuestsManager
    {
        List<Guest> GetGuests();
        List<EpisodeGuest> GetGuestEpisodes(string id);
        List<TotalNoGuests> GetNumberOfGuestTypes();
        int GetNumberOfGuests();
        Guest GetGuestById(string id);
        List<Guest> GetGuestsOrderedByDescription();
        void Create(GuestCreationModel model);
        void Update(GuestCreationModel model);
        void Delete(string id);
    }
}
