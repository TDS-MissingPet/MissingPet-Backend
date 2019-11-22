using MissingPet.BLL.Services;
using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using MissingPet.Domain.Models;
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
    [Route("api/images")]
    public class AdvertImageController : ApiController
    {
        private IAdvertImageService _repo;

        public AdvertImageController(IAdvertImageService repo)
        {
            _repo = repo;
        }

        // GET api/values
        [Route("api/images/{advertId}")]
        public async Task<HttpResponseMessage> Post(int advertId)
        {
            var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

            if (filesReadToProvider == null || !filesReadToProvider.Contents.Any())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"No images provided");
            }

            var resultUrls = new List<string>();

            foreach(var image in filesReadToProvider.Contents)
            {
                try
                {
                    var imageBytes = await image.ReadAsByteArrayAsync();
                    var fileName = image.Headers?.ContentDisposition?.FileName ?? DateTime.Now.ToString();

                    var advertImage = new AdvertImage();
                    advertImage.AdvertId = advertId;
                    advertImage.ImageData = imageBytes;
                    advertImage.Name = fileName;

                    var imageUrl = await _repo.Add(advertImage);
                    resultUrls.Add(imageUrl);
                }
                catch(Exception exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Was not able to save image. Messsage: {exception.Message}");
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, resultUrls);
        }
    }
}
