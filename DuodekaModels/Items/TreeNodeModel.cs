using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Items
{
    public class TreeNodeModel
    {
        private IItem innerItem { get; set; }
        private List<TreeNodeModel> innerChildren { get; set; }

        public string Name => innerItem.Name;
        public int NodeId => innerItem.Id;
        public string Path => innerItem.Path;

        public TreeNodeModel[] Children => innerChildren.ToArray();

        public TreeNodeModel(IItem item)
        {
            this.innerChildren = new List<TreeNodeModel>();
            this.innerItem = item;
        }

        public void AddChild(TreeNodeModel c)
        {
            innerChildren.Add(c);
        }
    }
}
