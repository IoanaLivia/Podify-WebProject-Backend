using Podify.Entities;
using Podify.Models;
using Podify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public class PodcastsManager : IPodcastsManager
    {
        private readonly IPodcastsRepository podcastsRepository;

        public PodcastsManager(IPodcastsRepository podcastsRepository)
        {
            this.podcastsRepository = podcastsRepository;
        }

        public List<Podcast> GetPodcasts()
        {
            return podcastsRepository.GetPodcastsIQueriable().ToList();
        }

        public Podcast GetPodcastById(string id)
        {
            var podcast = podcastsRepository
                  .GetPodcastsIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return podcast;
        }

        public void Create(PodcastCreationModel model)
        {
            var newPodcast = new Podcast
            {
                Id = model.Id,
                Title = model.Title,
                Details = model.Details,
                PodcastHostId = model.PodcastHostId
            };

            podcastsRepository.Create(newPodcast);
            
        }
        public void Update(PodcastCreationModel model)
        {
            var newPodcast = GetPodcastById(model.Id);
            newPodcast.Id = model.Id;
            newPodcast.Title = model.Title;
            newPodcast.Details = model.Details;
            newPodcast.PodcastHostId = model.PodcastHostId;

            podcastsRepository.Update(newPodcast);
        }

        public void Delete(string id)
        {
            var newPodcast = GetPodcastById(id);

            podcastsRepository.Delete(newPodcast);
        }


    }
}

