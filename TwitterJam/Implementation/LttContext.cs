using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttContext : TwitterContext
    {
        public LttContext(IAuthorizer authorizer)
            : base(authorizer)
        {

        }
    }
}
