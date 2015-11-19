using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.JsonResponses.Common
{
    public class Metadata
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
        [JsonProperty("etag")]
        public string etag { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
    }
}