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
    public class GroupsController : ApiController
    {
        public GroupsController()
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

        [HttpPost]
        [Route("groups/")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new group.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddGroup([FromBody] Group group)
        {
            return Ok();
        }

        [HttpPut]
        [Route("groups/{groupId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed group.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateGroup([FromUri] int groupId, [FromBody] Group group)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("groups/{groupId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed group.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteGroup([FromUri] int groupId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("groups/{groupId:int}/students")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of students.", Type = typeof(User[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetStudents([FromUri] int groupId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("groups/{groupId:int}/students/")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new student.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddStudent([FromBody] User student)
        {
            return Ok();
        }

        [HttpPut]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed student.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateStudent([FromUri] int studentId, [FromBody] User user)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("groups/{groupId:int}/students/{studentId:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed student.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteStudent([FromUri] int studentId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("groups/attendance/")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a attendance of a group on workshop.", Type = typeof(bool[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetAttendance([FromBody] int workshopId)
        {
            return Ok();
        }

        [HttpPut]
        [Route("groups/attendance/")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed attendance of student on workshop.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateAttendance([FromBody] int workshopId, [FromBody] int studentId)
        {
            return Ok();
        }
    }
}
