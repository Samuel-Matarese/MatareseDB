using MatareseDB.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatareseDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionController(CollectionService collectionService) : ControllerBase
    {
        [HttpGet("get-collection/{databaseName}/{collectionname}")]
        public async Task<IActionResult> GetCollection(string databaseName, string collectionname)
        {
            var data = await collectionService.GetCollection(databaseName, collectionname);
            return Ok(data);
        }

        [HttpPost("post-collection/{databaseName}/{collectionname}")]
        public async Task<IActionResult> PostCollection(string databaseName, string collectionname)
        {
            await collectionService.AddCollection(databaseName, collectionname);
            return Ok();
        }
    }
}
