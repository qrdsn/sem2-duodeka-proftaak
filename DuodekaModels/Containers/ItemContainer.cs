using DataAccessLayer.Services;
using DuodekaModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaBusiness.Containers
{
    public class ItemContainer
    {
        ItemService itemService = new ItemService();

        public IItem[] GetItemsInFolder(string path)
        {
            var items = itemService.GetItemsInDirectory(path).ConvertToItems();

            if (items == null || items.Count() < 1)
                throw new NullReferenceException();

            return items.ToArray();
        }
    }
}
