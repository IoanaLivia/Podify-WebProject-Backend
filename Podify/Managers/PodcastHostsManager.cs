using Podify.Entities;
using Podify.Models;
using Podify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public class PodcastHostsManager : IPodcastHostsManager
    {
        private readonly IPodcastHostsRepository hostsRepository;

        public PodcastHostsManager(IPodcastHostsRepository hostsRepository)
        {
            this.hostsRepository = hostsRepository;
        }

        public List<PodcastHost> GetPodcastHosts()
        {
            return hostsRepository.GetPodcastHostsIQueriable().ToList();
        }

        public PodcastHost GetPodcastHostById(string id)
        {
            var host = hostsRepository
                  .GetPodcastHostsIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return host;
        }

        public void Create(PodcastHostCreationModel model)
        {
            var newHost = new PodcastHost
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Description = model.Description
            };

            hostsRepository.Create(newHost);
        }
        public void Update(PodcastHostCreationModel model)
        {
            var newHost = GetPodcastHostById(model.Id);
            newHost.Id = model.Id;
            newHost.Name = model.Name;
            newHost.Surname = model.Surname;
            newHost.Description = model.Description;

            hostsRepository.Update(newHost);
        }

        public void Delete(string id)
        {
            var newHost = GetPodcastHostById(id);

            hostsRepository.Delete(newHost);
        }

        public List<PodcastHostPodcast> Join()
        {
            var res = hostsRepository.GetJoin().ToList();
            return res;
        }

    }
}

