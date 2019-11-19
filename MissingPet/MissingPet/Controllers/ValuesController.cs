using MissingPet.BLL.Services;
using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MissingPet.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private IAdvertImageService _repo;

        public ValuesController(IAdvertImageService repo)
        {
            _repo = repo;
        }

        // GET api/values
        public async Task Get()
        {
            var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

            //We will use two content part one is used to store the json another is used to store the image binary.
            var imageJson = await filesReadToProvider.Contents[0].ReadAsStringAsync();
            var fileBytes = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();

            var advertImage = JsonConvert.DeserializeObject<Domain.Models.AdvertImage>(imageJson);
            advertImage.ImageData = fileBytes;

            await _repo.Add(advertImage);
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
