using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.JsonResponses.TestItem
{
    public class TestItem
    {
        [JsonProperty("d")]
        public D d { get; set; }
    }
}
