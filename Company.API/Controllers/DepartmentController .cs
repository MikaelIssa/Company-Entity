using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
            private readonly IDbService _db;
            public DepartmentController(IDbService db) => _db = db;
       
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IResult> Get() =>
        Results.Ok(await _db.GetAsync<Department, DepartmentDTO>());

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result = (await _db.SingleAsync<Department, DepartmentDTO>(e => e.Id.Equals(id)));
            if (result is null) return Results.NotFound();
            return Results.Ok(result);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        //public void Post([FromBody] string value)
        
            public async Task<IResult> Post([FromBody] DepartmentDTO dto)
            {
                try
                {
                    var entity = await _db.AddAsync<Department, DepartmentDTO>(dto);

                    if (await _db.SaveChangesAsync())
                    {
                        var node = typeof(Department).Name.ToLower();
                        return Results.Created($"/{node}s/{entity.Id}", entity);
                    }

                    return Results.BadRequest();
                }

                catch (Exception ex)
                {
                    return Results.BadRequest($"Couldn't add the {typeof(Department).Name} entity.");
                }


            }


        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DepartmentDTO dto)
        {
            try
            {
                if (!await _db.AnyAsync<Department>(e => e.Id.Equals(id)))

                {
                    return Results.NotFound();
                }
                _db.Update<Department, DepartmentDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }

            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't update the {typeof(Department).Name} entity.");

            }
            return Results.BadRequest();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete<TEntity>(int id) where TEntity : class, IEntity

        {
            try
            {
                if (!await _db.DeleteAsync<Department>(id)) return Results.NotFound();

                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }

            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(Department).Name} entity.");
            }

            return Results.BadRequest();
        }
    }
}
