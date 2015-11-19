using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.JsonResponses.TestList
{
    public class D
    {
        [JsonProperty("results")]
        public IList<Result> results { get; set; }
    }
}