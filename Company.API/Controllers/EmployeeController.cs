using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
            private readonly IDbService _db;
            public EmployeeController(IDbService db) => _db = db;
       
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IResult> Get() =>
        Results.Ok(await _db.GetAsync<Employee, EmployeeDTO>());

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result = (await _db.SingleAsync<Employee, EmployeeDTO>(e => e.Id.Equals(id)));
            if (result is null) return Results.NotFound();
            return Results.Ok(result);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        //public void Post([FromBody] string value)
        
            public async Task<IResult> Post([FromBody] EmployeeDTO dto)
            {
                try
                {
                    var entity = await _db.AddAsync<Employee, EmployeeDTO>(dto);

                    if (await _db.SaveChangesAsync())
                    {
                        var node = typeof(Employee).Name.ToLower();
                        return Results.Created($"/{node}s/{entity.Id}", entity);
                    }

                    return Results.BadRequest();
                }

                catch (Exception ex)
                {
                    return Results.BadRequest($"Couldn't add the {typeof(Employee).Name} entity.");
                }


            }
        

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] EmployeeDTO dto)
        {
            try
            {
                if (!await _db.AnyAsync<Employee>(e => e.Id.Equals(id)))

                {
                    return Results.NotFound();
                }
                _db.Update<Employee, EmployeeDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }

            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't update the {typeof(Employee).Name} entity.");

            }
            return Results.BadRequest();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete<TEntity>(int id) where TEntity : class, IEntity

        {
            try
            {
                if (!await _db.DeleteAsync<Employee>(id)) return Results.NotFound();

                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }

            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(Employee).Name} entity.");
            }

            return Results.BadRequest();
        }
    }
}
