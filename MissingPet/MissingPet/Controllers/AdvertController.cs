using MissingPet.BLL.Services;
using MissingPet.Domain.Models;
using MissingPet.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MissingPet.Controllers
{
    [Authorize]
    [Route("api/adverts")]
    public class AdvertController : ApiController
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public HttpResponseMessage Post([FromBody]Advert advert)
        {
            if(advert == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, $"Model is empty");
            }

            try
            {
                var result = _advertService.Add(advert);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
            }
            catch(ArgumentNullException exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, exception.Message);
            }
            catch(Exception exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, exception);
            }
        }

        public HttpResponseMessage Get([FromUri] AdvertsFilterRequestModel filters, [FromUri] AdvertsSortRequestModel sortInfo,
            [FromUri] int pageNumber = 0, [FromUri] int pageSize = 10)
        {
            try
            {
                var result = _advertService.GetAll(filters, sortInfo, pageNumber, pageSize);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
            }
            catch (ArgumentNullException exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, exception.Message);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [Route("api/adverts/{advertId}")]
        public HttpResponseMessage Get(int advertId)
        {
            if(advertId == 0)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Please provide advert id");
            }

            try
            {
                var result = _advertService.GetById(advertId);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
            }
            catch (ArgumentNullException exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, exception.Message);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}