using BLL.JsonResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.JsonResponses
{
    public class Metadata
    {
        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class SupportedSchemaVersions
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata { get; set; }
        [JsonProperty("results")]
        public IList<string> results { get; set; }
    }

    public class GetContextWebInformation
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata { get; set; }
        [JsonProperty("FormDigestTimeoutSeconds")]
        public int FormDigestTimeoutSeconds { get; set; }
        [JsonProperty("FormDigestValue")]
        public string FormDigestValue { get; set; }
        [JsonProperty("LibraryVersion")]
        public string LibraryVersion { get; set; }
        [JsonProperty("SiteFullUrl")]
        public string SiteFullUrl { get; set; }
        [JsonProperty("SupportedSchemaVersions")]
        public SupportedSchemaVersions SupportedSchemaVersions { get; set; }
        [JsonProperty("WebFullUrl")]
        public string WebFullUrl { get; set; }
    }

    public class D
    {
        [JsonProperty("GetContextWebInformation")]
        public GetContextWebInformation GetContextWebInformation { get; set; }
    }

    public class ContextInfo
    {
        [JsonProperty("d")]
        public D d { get; set; }
    }
}
