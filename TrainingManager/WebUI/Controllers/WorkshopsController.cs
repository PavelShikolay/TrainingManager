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
    [RoutePrefix("api/workshops")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [SwaggerResponseRemoveDefaults]
    public class WorkshopsController : ApiController
    {
        public WorkshopsController()
        {
        }

        [HttpGet]
        [Route("groups")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of groups.", Type = typeof(Group[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetGroups()
        {
            return Ok();
        }

        [HttpGet]
        [Route("groups/{groupId:int}/")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of modules.", Type = typeof(Workshop[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetWorkshops([FromUri] int groupId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("groups/{groupId:int}/")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new workshop.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddWorkshop([FromUri] int groupId, [FromBody] Workshop workshop)
        {
            return Ok();
        }

        [HttpPut]
        [Route("groups/{groupId:int}/{workshopId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed workshop.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateWorkshop([FromUri] int workshopId, [FromBody] Workshop workshop)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("groups/{groupId:int}/{workshopId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed workshop.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteWorkshop(int workshopId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("groups/{groupId:int}/{workshopId:int}/attendance")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of groups.", Type = typeof(Group[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetAttendance(int workshopId)
        {
            return Ok();
        }

        //public async Task<IHttpActionResult> SendRequest(int workshopId)
        //{
        //    return Ok();
        //}

        //public async Task<IHttpActionResult> SendWorkshopCancelation(int workshopId)
        //{
        //    return Ok();
        //}
    }
}
