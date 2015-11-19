using BLL.Interface.Services;
using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security;
using Microsoft.SharePoint.Client;
using System.Net;
using BLL.Builders;
using System.IO;
using BLL.JsonResponses.TestItem;
using BLL.JsonResponses.TestList;
using BLL.JsonResponses;

namespace BLL.Services
{
    public class TestListService : ITestListService
    {
        private SharePointOnlineCredentials credentials;
        private string entityType = "SP.Data.Test_x0020_ListListItem";

        public TestListService()
        {
            const string userName = "Aliaksandr_Chechat@podlesky.onmicrosoft.com";
            const string password = "BlackJack1!";
            var securePassword = new SecureString();
            foreach (var c in password)
            {
                securePassword.AppendChar(c);
            }
            credentials = new SharePointOnlineCredentials(userName, securePassword);
        }

        public void AddItem(TestListItemEntity entity)
        {
            var contextInfo = GetContextInfo();
            string itemPostBody = (new TestListItemBuilder()).WithType(entityType).WithItem(entity).Build();
            Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);

            var url = new TestListBuilder().FromList("Test List").WithAllItems().Build();
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = itemPostBody.Length;
            request.ContentType = "application/json;odata=verbose";
            request.Credentials = credentials;
            request.Accept = "application/json;odata=verbose";
            request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            request.Headers.Add("X-RequestDigest", contextInfo.d.GetContextWebInformation.FormDigestValue);
            Stream itemRequestStream = request.GetRequestStream();

            itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
            itemRequestStream.Close();

            HttpWebResponse itemResponse = (HttpWebResponse)request.GetResponse();
        }

        public void UpdateItem(TestListItemEntity entity)
        {
            var contextInfo = GetContextInfo();
            string itemPostBody = (new TestListItemBuilder()).WithType(entityType).WithItem(entity).Build();
            Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);

            var url = new TestListBuilder().FromList("Test List").WithItem(entity.Id).Build();
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = itemPostBody.Length;
            request.ContentType = "application/json;odata=verbose";
            request.Credentials = credentials;
            request.Accept = "application/json;odata=verbose";
            request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            request.Headers.Add("X-RequestDigest", contextInfo.d.GetContextWebInformation.FormDigestValue);
            request.Headers.Add("X-HTTP-Method", "MERGE");
            request.Headers.Add("IF-MATCH", "*");
            Stream itemRequestStream = request.GetRequestStream();

            itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
            itemRequestStream.Close();

            HttpWebResponse itemResponse = (HttpWebResponse)request.GetResponse();
        }

        public void DeleteItem(int Id)
        {
            var contextInfo = GetContextInfo();
            var url = new TestListBuilder().FromList("Test List").WithItem(Id).Build();
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.Credentials = credentials;
            request.ContentLength = 0;
            request.Headers.Add("IF-MATCH", "*");
            request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            request.Headers.Add("X-RequestDigest", contextInfo.d.GetContextWebInformation.FormDigestValue);
            request.Headers.Add("X-HTTP-Method", "DELETE");
            HttpWebResponse itemResponse = (HttpWebResponse)request.GetResponse();
        }

        public TestListItemEntity GetItem(int id)
        {
            var url = new TestListBuilder().FromList("Test List").WithItem(id).Build();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json;odata=verbose";
            request.ContentType = "application/json;odata=verbose";
            request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            request.Credentials = credentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            var item = ((TestItem)JsonConvert.DeserializeObject<TestItem>(stream.ReadLine())).d;
            return new TestListItemEntity()
            {
                Id = item.Id,
                Title = item.Title,
                Experience = item.Experience
            };
        }

        public IList<TestListItemEntity> GetAllItems()
        {
            var url = new TestListBuilder().FromList("Test List").WithAllItems().Build();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json;odata=verbose";
            request.ContentType = "application/json;odata=verbose";
            request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            request.Credentials = credentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            var testList = (TestList)JsonConvert.DeserializeObject<TestList>(stream.ReadLine());
            var result = new List<TestListItemEntity>();
            foreach(var item in testList.d.results)
            {
                var temp = new TestListItemEntity()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Experience = item.Experience
             
                };
                result.Add(temp);
            }
            return result;
        }

        private ContextInfo GetContextInfo()
        {
            HttpWebRequest request =
    (HttpWebRequest)HttpWebRequest.Create("https://podlesky.sharepoint.com/Aliaksandr_Chechat/_api/contextinfo");
            request.Method = "POST";
            request.Accept = "application/json;odata=verbose";
            request.ContentLength = 0;
            request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            request.Credentials = credentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            return (ContextInfo)JsonConvert.DeserializeObject<ContextInfo>(stream.ReadLine());
        }
    }
}
