using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Builders
{
    public class TestListBuilder
    {
        private const string lists = "https://podlesky.sharepoint.com/Aliaksandr_Chechat/_api/web/lists/";
        private StringBuilder strBuilder;

        public TestListBuilder()
        {
            strBuilder = new StringBuilder(lists);
        }

        public TestListBuilder FromList(string list)
        {
            strBuilder.Append(String.Format("getByTitle('{0}')", list));
            return this;
        }

        public TestListBuilder WithAllItems()
        {
            strBuilder.Append("/items");
            return this;
        }

        public TestListBuilder WithItem(int id)
        {
            strBuilder.Append(String.Format("/items({0})", id));
            return this;
        }

        public string Build()
        {
            return strBuilder.ToString();
        }
    }
}
