using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ioasysAPI.Core;
using ioasysAPI.Models;
using ioasysAPI.ViewModels;


namespace ioasysAPI.Controllers
{

  
    public class MoviesController : ApiController
    {
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 200, description: "Busca de Filmes Realizado com suas especificas Reviews")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 400, description: "Erro ao buscar filmes com suas reviews")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {            
            using (var context = new MovieContext())
            {
                return Ok(await context.Movies.Include(x => x.Reviews).ToListAsync());
            }

        }
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 200, description: "Busca de filmes a partir do seu id, juntamente com suas reviews")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 400, description: "Erro ao buscar filmes com suas Reviews a partir do ID")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new MovieContext())
            {
                return Ok(await context.Movies.Include(x => x.Reviews).FirstOrDefaultAsync(b => b.Id == id));
            }
        }
    }
}
