using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ioasysAPI.Core
{
    public class MovieUserStore : UserStore<IdentityUser>
    {
        public MovieUserStore() : base(new MovieContext())
        {

        }
    }
}