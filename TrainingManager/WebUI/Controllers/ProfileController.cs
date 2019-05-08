using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;
using BLL.Interfaces.Entities;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;


namespace WebUI.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/profile")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [SwaggerResponseRemoveDefaults]
    public class ProfileController : ApiController
    {
        public ProfileController()
        {
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a profile of current user.", Type = typeof(Module[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetUser([FromBody] int userId)
        {
            return Ok();
        }

        [HttpPut]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates profile of current user.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateUser([FromBody] int userId, User user)
        {
            return Ok();
        }
    }
}
