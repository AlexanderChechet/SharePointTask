using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Builders
{
    public class TestListItemBuilder
    {
        private StringBuilder strBuilder;

        public TestListItemBuilder()
        {
            strBuilder = new StringBuilder("{'__metadata':");
        }

        public TestListItemBuilder WithType(string type)
        {
            strBuilder.Append("{'type':'");
            strBuilder.Append(type);
            strBuilder.Append("'}, ");
            return this;
        }

        public TestListItemBuilder WithItem(TestListItemEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach(var item in properties)
            {
                if (item.Name != "Id")
                {
                    var str = String.Format("'{0}':'{1}',", item.Name, item.GetValue(entity));
                    strBuilder.Append(str);
                }
            }
            strBuilder.Remove(strBuilder.Length - 1, 1);
            strBuilder.Append("}");
            return this;
        }

        public string Build()
        {
            return strBuilder.ToString();
        }
    }
}
