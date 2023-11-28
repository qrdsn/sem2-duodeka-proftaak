using DuodekaModels.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Items
{
    public interface IItem
    {
        public int Id { get; }
        public int CreatorId { get; }
        public string CreatorName { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; }
        public ItemTypes ItemType { get; }
        public DateTime Created { get; }
        public DateTime? Modified { get;  }
        public bool Availability { get; }
        public string CreatedText { get; }
        public string IconName { get; }

        public int MoveTo(string newLocation);

        public static IItem CreateInstance(SqlDataReader rdr)
        {
            ItemTypes itemType = (ItemTypes)rdr.GetNonNullableValue<int>("type");

            switch (itemType)
            {
                case ItemTypes.Project:
                    return new ProjectModel(rdr);
                case ItemTypes.Directory:
                    return new DirectoryModel(rdr);
                case ItemTypes.File:
                    return new FileModel(rdr);
                default:
                    return null;
            }
        }
    }
}
