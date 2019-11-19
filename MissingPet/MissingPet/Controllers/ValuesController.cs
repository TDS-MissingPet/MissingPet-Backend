using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MissingPet.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private IRepository<Advert> _repo;

        public ValuesController(IRepository<Advert> repo)
        {
            _repo = repo;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            _repo.Add(new Advert());
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
