using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.WebApi;
using UmbracoCI.Extensions.Repositories;

namespace UmbracoCI.Extensions.ApiControllers
{
    class SampleApiController : UmbracoApiController
    {
        private ISampleRepository _repo;

        public SampleApiController(ISampleRepository repository)
            : base()
        {
            _repo = repository;
        }

        public object Get(int id)
        {
            return _repo.Get(id);
        }
    }
}
