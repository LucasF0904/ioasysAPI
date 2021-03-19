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
    public class ReviewsController : ApiController
    {
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 200, description: "Inserção de Review Realizado")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 400, description: "Erro ao cadastrar Review")]
        [HttpPost]

        public async Task<IHttpActionResult> Post([FromBody] ReviewViewModel review)
        {
            using (var context = new MovieContext())
            {
                var movie = await context.Movies.FirstOrDefaultAsync(b => b.Id == review.MovieId);
                if (movie == null)
                {
                    return NotFound();
                }

                var newReview = context.Reviews.Add(new Review
                {
                    MovieId = movie.Id,
                    Description = review.Description,
                    Rating = review.Rating
                });

                await context.SaveChangesAsync();
                return Ok(new ReviewViewModel(newReview));
            }
        }
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 200, description: "Deleção de Review Realizado")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 400, description: "Erro ao Deletar Review")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new MovieContext())
            {
                var review = await context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
                if (review == null)
                {
                    return NotFound();
                }

                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
