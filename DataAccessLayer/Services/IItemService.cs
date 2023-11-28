using DuodekaModels;
using DuodekaModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IItemService
    {
        public int InsertItem(object item, InsertItemModel itemModel, int parentItemId);
        public int EditItem(IItem item);
        public int DeleteItem(int itemId);
        public IItem[] GetItemsInDirectory(string parentPath);
        public TreeNodeModel[] GetTreeView(int userId);


    }
}
