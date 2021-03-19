using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ioasysAPI.Core
{
    public class Initializer : MigrateDatabaseToLatestVersion<MovieContext, Configuration>
    {
    }
}