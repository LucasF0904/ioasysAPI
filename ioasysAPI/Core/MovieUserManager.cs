using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ioasysAPI.Core
{
    public class MovieUserManager : UserManager<IdentityUser>
    {
        public MovieUserManager() : base(new MovieUserStore())
        {

        }
    }
}