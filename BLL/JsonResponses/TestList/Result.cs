using BLL.JsonResponses.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.JsonResponses.TestList
{
    public class Result
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata { get; set; }
        [JsonProperty("FirstUniqueAncestorSecurableObject")]
        public FirstUniqueAncestorSecurableObject FirstUniqueAncestorSecurableObject { get; set; }
        [JsonProperty("RoleAssignments")]
        public RoleAssignments RoleAssignments { get; set; }
        [JsonProperty("AttachmentFiles")]
        public AttachmentFiles AttachmentFiles { get; set; }
        [JsonProperty("ContentType")]
        public ContentType ContentType { get; set; }
        [JsonProperty("GetDlpPolicyTip")]
        public GetDlpPolicyTip GetDlpPolicyTip { get; set; }
        [JsonProperty("FieldValuesAsHtml")]
        public FieldValuesAsHtml FieldValuesAsHtml { get; set; }
        [JsonProperty("FieldValuesAsText")]
        public FieldValuesAsText FieldValuesAsText { get; set; }
        [JsonProperty("FieldValuesForEdit")]
        public FieldValuesForEdit FieldValuesForEdit { get; set; }
        [JsonProperty("File")]
        public File File { get; set; }
        [JsonProperty("Folder")]
        public Folder Folder { get; set; }
        [JsonProperty("ParentList")]
        public ParentList ParentList { get; set; }
        [JsonProperty("FileSystemObjectType")]
        public int FileSystemObjectType { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("ContentTypeId")]
        public string ContentTypeId { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Experience")]
        public int Experience { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Modified")]
        public DateTime Modified { get; set; }
        [JsonProperty("Created")]
        public DateTime Created { get; set; }
        [JsonProperty("AuthorId")]
        public int AuthorId { get; set; }
        [JsonProperty("EditorId")]
        public int EditorId { get; set; }
        [JsonProperty("OData__UIVersionString")]
        public string OData__UIVersionString { get; set; }
        [JsonProperty("Attachments")]
        public bool Attachments { get; set; }
        [JsonProperty("GUID")]
        public string GUID { get; set; }
    }
}