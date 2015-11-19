using BLL.Interface.Entities;
using MvcL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcL.Mappers
{
    public static class TestListMapper
    {
        public static TestListItemModel ToTestListItemModel(this TestListItemEntity entity)
        {
            return new TestListItemModel()
            {
                Id = entity.Id,
                Experience = entity.Experience,
                Title = entity.Title
            };
        }

        public static TestListItemEntity ToTestListItemEntity(this TestListItemModel model)
        {
            return new TestListItemEntity()
            {
                Id = model.Id,
                Experience = model.Experience,
                Title = model.Title
            };
        }
    }
}