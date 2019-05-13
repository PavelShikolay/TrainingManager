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
    [RoutePrefix("api/grow")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [SwaggerResponseRemoveDefaults]
    public class GrowController : ApiController
    {
        public GrowController()
        {

        }

        [HttpGet]
        [Route("groups/")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of groups.", Type = typeof(Group[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetGroups()
        {
            return Ok();
        }

        [HttpGet]
        [Route("modules/")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of modules.", Type = typeof(Module[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetModules()
        {
            return Ok();
        }

        [HttpGet]
        [Route("modules/{moduleId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a module.", Type = typeof(Module))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetModule([FromUri] int moduleId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("modules/")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new module.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddModule([FromBody] Module updateModuleRequest)
        {
            return Ok();
        }

        [HttpPut]
        [Route("modules/{moduleId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed module.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateModule([FromUri] int moduleId, Module updateModuleRequest)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("modules/{moduleId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed module.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteModule([FromUri] int moduleId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("studentModules/")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of student modules.", Type = typeof(StudentModule[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetStudentModules()
        {
            return Ok();
        }

        [HttpPost]
        [Route("studentModules/{moduleId:int}")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a student module instance of module for all students.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddStudentModules([FromUri] int moduleId)
        {
            return Ok();
        }

        [HttpPut]
        [Route("studentModules/{moduleId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed student module.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateStudentModule([FromUri] int id, StudentModule updateStudentModule)
        {
            return Ok();
        }
    }
}
