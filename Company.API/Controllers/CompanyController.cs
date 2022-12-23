using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
            private readonly IDbService _db;
            public CompanyController(IDbService db) => _db = db;

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IResult> Get() =>
        Results.Ok(await _db.GetAsync<Business, BusinessDTO>());

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result = (await _db.SingleAsync<Business, BusinessDTO>(e => e.Id.Equals(id)));
            if (result is null) return Results.NotFound();
            return Results.Ok(result);
        }

        // POST api/<CompanyController>
        [HttpPost]
        //public void Post([FromBody] string value)
        
            public async Task<IResult> Post([FromBody] BusinessDTO dto)
            {
                try
                {
                    var entity = await _db.AddAsync<Business, BusinessDTO>(dto);

                    if (await _db.SaveChangesAsync())
                    {
                        var node = typeof(Business).Name.ToLower();
                        return Results.Created($"/{node}s/{entity.Id}", entity);
                    }

                    return Results.BadRequest();
                }

                catch (Exception ex)
                {
                    return Results.BadRequest($"Couldn't add the {typeof(Business).Name} entity.");
                }


            }
        

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] BusinessDTO dto)
        {
            try
            {
                if (!await _db.AnyAsync<Business>(e => e.Id.Equals(id)))

                {
                    return Results.NotFound();
                }
                _db.Update<Business, BusinessDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }

            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't update the {typeof(Business).Name} entity.");

            }
            return Results.BadRequest();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete<TEntity>(int id) where TEntity : class, IEntity

        {
            try
            {
                if (!await _db.DeleteAsync<Business>(id)) return Results.NotFound();

                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }

            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(Business).Name} entity.");
            }

            return Results.BadRequest();
        }
    }
}
