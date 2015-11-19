using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.JsonResponses.TestList
{
    public class TestList
    {
        [JsonProperty("d")]
        public D d { get; set; }
    }
}