using Company.Common.DTOs;
using Company.Data.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTitleController : ControllerBase
    {
        private readonly IDbService _db;
        public EmployeeTitleController(IDbService db) => _db = db;

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeeTitlesDTO dto)
        {
            try
            {
                var entity = await _db.AddAsync<EmployeeTitle, EmployeeTitlesDTO>(dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch
            {
            }



            return Results.BadRequest($"Couldn't add the {typeof(EmployeeTitle).Name} entity.");
        }



        [HttpDelete]
        public async Task<IResult> Delete(EmployeeTitlesDTO dto)
        {
            try
            {
                if (!_db.Delete<EmployeeTitle, EmployeeTitlesDTO>(dto)) return Results.NotFound();



                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch
            {
            }



            return Results.BadRequest($"Couldn't delete the {typeof(EmployeeTitle).Name} entity.");
        }
    }
}
