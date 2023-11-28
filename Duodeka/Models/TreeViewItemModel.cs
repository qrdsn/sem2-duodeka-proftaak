using DuodekaModels.Items;

namespace Duodeka.Models
{
    public class TreeViewItemModel
    {
        public string ItemName => BaseItem.Name;
        public string DateCreated => BaseItem.CreationDateText;
        public ItemTypes ItemType => BaseItem.ItemType;
        public double Size { get; set; }
        public string Path => BaseItem.Path;
        public string CreatorName =>  BaseItem.CreatorName;
        public IItem BaseItem { get; protected set; }
        public string IconName { get; protected set; }

        public TreeViewItemModel(IItem baseItem)
        {
            BaseItem = baseItem;

            switch (baseItem.ItemType)
            {
                case ItemTypes.Directory:
                    IconName = "folder";
                    break;
                case ItemTypes.Project:
                    IconName = "project";
                    break;
                default:
                    IconName = "border";
                    break;
            }
        }
    }
}
