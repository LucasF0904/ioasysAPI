using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ioasysAPI.Models;
using ioasysAPI.Core;


namespace ioasysAPI.Core
{
    public class Configuration : DbMigrationsConfiguration<MovieContext>
    {
        public Movies movies = new Movies();
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 200, description:"Inserção a partir de context Realizado")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(statusCode: 400, description: "Erro ao cadastrar dados no Banco de Dados a partir do context")]
        protected override void Seed(MovieContext context)
        {            
            
            context.Reviews.AddOrUpdate(new Review { MovieId = 1, Id = 1, Rating = 4, Description = "Adorei o Filme!" });
            context.Reviews.AddOrUpdate(new Review { MovieId = 1, Id = 2, Rating = 4, Description = "Ótimo filme, porém curto." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 1, Id = 3, Rating = 3, Description = "Bom Filme, mas não assistiria duas vezes." });

            context.Reviews.AddOrUpdate(new Review { MovieId = 2, Id = 4, Rating = 5, Description = "Esplêndido!" });
            context.Reviews.AddOrUpdate(new Review { MovieId = 2, Id = 5, Rating = 5, Description = "Melhor filme de todos?" });
            context.Reviews.AddOrUpdate(new Review { MovieId = 2, Id = 6, Rating = 5, Description = "Meu filme favorito de todos os tempos." });

            context.Reviews.AddOrUpdate(new Review { MovieId = 3, Id = 7, Rating = 4, Description = "Filme divertido." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 3, Id = 8, Rating = 4, Description = "Filme bem casual." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 3, Id = 9, Rating = 5, Description = "Bom filme mas não agrega muito." });

            context.Reviews.AddOrUpdate(new Review { MovieId = 4, Id = 10, Rating = 3, Description = "Muito bom para pessoas novas." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 4, Id = 11, Rating = 4, Description = "Bom, em alguns pontos." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 4, Id = 12, Rating = 3, Description = "Não é para o publico experiente." });

            context.Reviews.AddOrUpdate(new Review { MovieId = 5, Id = 13, Rating = 3, Description = "Primeira parte do filme é demais... A segunda é terrível." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 5, Id = 14, Rating = 4, Description = "Achei o filme monótono." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 5, Id = 15, Rating = 5, Description = "Não precisa ser um cineasta para entender, recomendo totalmente." });

            context.Reviews.AddOrUpdate(new Review { MovieId = 6, Id = 16, Rating = 5, Description = "Muito melhor que o livro." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 6, Id = 17, Rating = 4, Description = "Educacional." });
            context.Reviews.AddOrUpdate(new Review { MovieId = 6, Id = 18, Rating = 3, Description = "Muito longo o filme." });


            context.Movies.AddOrUpdate(new Movies
            {
                Id = 1,
                Title = "Aladdin",
                Description = "Filme direcionado ao publico infantil de fanasia, aonde é apresentado um jovem que encontra-se perdido, e procura ter sucesso, quando encontra uma lampadâ.",
                ImageUrl = "https://pereirabarreto.sp.gov.br/wp-content/uploads/2020/01/Aladdin-1.jpg"
            });

            context.Movies.AddOrUpdate(new Movies
            {
                Id = 2,
                Title = "Sonic",
                Description = "Filme direcionado ao public infantil de fantasia, aonde é apresentado um ser que possui supervelocidade e seus vilôes.",
                ImageUrl = "https://ingresso-a.akamaihd.net/img/cinema/cartaz/22968-cartaz.jpg"
            });

            context.Movies.AddOrUpdate(new Movies
            {
                Id = 3,
                Title = "Vingadores Ultimato",
                Description = "Final da história começada em Vingadores Guerra Infinita, tendo como objetivo mostrar a vida após os desastres causados por Thanos e a recuperação dos vingadores para trazer todos de volta.",
                ImageUrl = "https://www.claro.com.br/imagem/vingadores-1509142971425.jpg"
            });

            context.Movies.AddOrUpdate(new Movies
            {
                Id = 4,
                Title = "A Culpa é das Estrelas",
                Description = "Filme que apresenta a historia de jovens que possuem problemas graves de saude, e se juntam para aproveitar seus ultimos momentos.",
                ImageUrl = "https://cdn.maioresemelhores.com/imagens/maiores-e-melhores-filmes-para-chorar-03.jpg"
            });

            context.Movies.AddOrUpdate(new Movies
            {
                Id = 5,
                Title = "John Wick",
                Description = "Assasino aposentado em busca de vingança pela morte do cachorro dado a ele por sua esposa recentemente falecida e por roubar seu carro.",
                ImageUrl = "https://www.oficinadanet.com.br/imagens/post/30278/330xNx82674928-culturafilme-john-wick-3parabellum-com-keanu-reeves-divulgacao-niko-tavernise.jpg.pagespeed.ic.ffc1650d65.jpg"
            });

            context.Movies.AddOrUpdate(new Movies
            {
                Id = 6,
                Title = "Avatar",
                Description = "Filme de grande sucesso da Disney que conta a invasão humana em outros planetas e seus 'Avatares', que se encontram com os habitantes locais, gerando diversos confiltos.",
                ImageUrl = "https://tecnoblog.net/meiobit/wp-content/uploads/2020/01/20200131avatar_1-680x382.jpg"
            });

            string adminRoleId;
            string userRoleId;
            if (!context.Roles.Any())
            {
                adminRoleId = context.Roles.Add(new IdentityRole("Administrator")).Id;
                userRoleId = context.Roles.Add(new IdentityRole("User")).Id;
            }
            else
            {
                adminRoleId = context.Roles.First(c => c.Name == "Administrator").Id;
                userRoleId = context.Roles.First(c => c.Name == "User").Id;
            }

            context.SaveChanges();

            if (!context.Users.Any())
            {
                var administrator = context.Users.Add(new IdentityUser("administrator") { Email = "admin@ioasys.com", EmailConfirmed = true });
                administrator.Roles.Add(new IdentityUserRole { RoleId = adminRoleId });

                var standardUser = context.Users.Add(new IdentityUser("lucasf") { Email = "lucas.faria1@gmail.com", EmailConfirmed = true });
                standardUser.Roles.Add(new IdentityUserRole { RoleId = userRoleId });

                context.SaveChanges();

                var store = new MovieUserStore();
                store.SetPasswordHashAsync(administrator, new MovieUserManager().PasswordHasher.HashPassword("administrator123"));
                store.SetPasswordHashAsync(standardUser, new MovieUserManager().PasswordHasher.HashPassword("user123"));
            }

            context.SaveChanges();
        }
    }
}