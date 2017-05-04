using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Api.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SongController : Controller
    {
        public int Get(ulong id)
        {
            return 1;
        }

        public long Post(string sha1)
        {

        }
    }
}
