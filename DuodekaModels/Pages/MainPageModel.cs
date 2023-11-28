using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaBusiness.Pages
{
    public class MainPageModel
    {
        public TreeNodeModel[] TreeView { get; set; }
        public IItem[] Rows { get; set; }
    }
}
