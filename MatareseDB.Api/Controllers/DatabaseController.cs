using MatareseDB.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatareseDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController(DatabaseService databaseService) : ControllerBase
    {
        [HttpPost("post-database/{databaseName}")]
        public async Task<IActionResult> CreateDatabase(string databaseName)
        {
            await databaseService.CreateDatabase(databaseName);
            return Ok();
        }

        [HttpDelete("delete-database/{databaseName}")]
        public async Task<IActionResult> DeleteDatabase(string databaseName)
        {
            await databaseService.DeleteDatabase(databaseName);
            return Ok();
        }
    }
}
