using MissingPet.BLL.Services;
using MissingPet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MissingPet.Controllers
{
    [Route("tags")]
    public class TagController : ApiController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var result = _tagService.GetAll();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
            }
            catch(Exception exception)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}