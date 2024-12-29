using MatareseDB.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatareseDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjectController(ObjectService objectService) : ControllerBase
    {
        [HttpGet("get-object/{databaseName}/{collectionName}/{id}")]
        public async Task<IActionResult> GetObject(string databaseName, string collectionName, Guid id)
        {
            var data = await objectService.GetObject(databaseName, collectionName, id);
            return Ok(data);
        }

        [HttpPost("post-object/{databaseName}/{collectionname}")]
        public async Task<IActionResult> PostObject([FromBody] object dataObject, string databaseName, string collectionname)
        {
            await objectService.AddObjectToCollection(dataObject, databaseName, collectionname);
            return Ok();
        }

        [HttpPut("update-object/{databaseName}/{collectionName}/{id}")]
        public async Task<IActionResult> PutObject(string databaseName, string collectionName, Guid id)
        {
            return Ok();
        }
    }
}
