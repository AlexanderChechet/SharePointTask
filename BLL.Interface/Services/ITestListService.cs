using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface ITestListService
    {
        void AddItem(TestListItemEntity entity);
        void UpdateItem(TestListItemEntity entity);
        void DeleteItem(int Id);
        TestListItemEntity GetItem(int id);
        IList<TestListItemEntity> GetAllItems();
    }
}
