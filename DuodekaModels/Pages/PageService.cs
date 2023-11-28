using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaBusiness.Pages
{
    public class PageService
    {
        public MainPageModel GetMainPage()
        {
/*            IItem[] items = itemService.GetItemsInDirectory("R://2/9");

            DataGridRowModel[] rows = new DataGridRowModel[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                rows[i] = new DataGridRowModel(items[i]);
            }

            TreeNodeModel[] treeitems = itemService.GetTreeView(1);

            var output = new MainPageModel
            {
                Rows = rows,
                TreeView = treeitems
            };*/


            var items = itemDTOs.ConvertToItems().ToArray();

            throw new NotImplementedException();
        }
    }
}
