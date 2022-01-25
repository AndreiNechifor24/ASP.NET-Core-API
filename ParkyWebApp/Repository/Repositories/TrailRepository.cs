using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ParkyWebApp.Models;
using ParkyWebApp.Repository.IRepository;

namespace ParkyWebApp.Repository.Repositories
{
    public class TrailRepository : Repository<Trailer>, ITrailRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public TrailRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
