using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ioasysAPI.Models;

namespace ioasysAPI.Core
{
    public class MovieContext : IdentityDbContext
    {
        public MovieContext()
            : base("MoviesContext")
        {

        }        
        public DbSet<Movies> Movies {get;set;}
        public DbSet<Review> Reviews { get; set; }
    }
}