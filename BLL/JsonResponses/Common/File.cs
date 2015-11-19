using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.JsonResponses.Common
{
    public class File
    {
        [JsonProperty("__deferred")]
        public Deferred __deferred { get; set; }
    }
}
