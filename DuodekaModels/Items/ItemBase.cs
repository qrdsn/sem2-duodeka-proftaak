using DuodekaModels.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Items
{
    public abstract class ItemBase : IItem
    {
        protected int id;
        protected int creator;
        protected string creatorName;
        protected string name;
        protected string description;
        protected string path;
        protected ItemTypes itemType;
        protected DateTime created;
        protected DateTime? modified;
        protected bool availability;

        #region IItem implementatie

        public int Id => id;

        public int CreatorId => creator;

        public string CreatorName => creatorName;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Path => path;

        public ItemTypes ItemType => itemType;

        public DateTime Created => created;

        public DateTime? Modified
        {
            get => modified;
            set => modified = value;
        }

        public bool Availability
        {
            get => availability;
            set => availability = value;
        }

        public string IconName => "folder";

        public string CreatedText => created.ToString("dd MMM yyyy");

        public int MoveTo(string newLocation)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ItemBase(SqlDataReader rdr)
        {
            name = rdr.GetNonNullableValue<string>("name");
            path = rdr.GetNullableValue<string>("path");
            itemType = (ItemTypes)rdr.GetNonNullableValue<int>("type");
            id = rdr.GetNonNullableValue<int>("item_id");
            availability = rdr.GetNonNullableValue<bool>("availability");
            description = rdr.GetNullableValue<string>("description");
            creator = rdr.GetNonNullableValue<int>("creator_id");
            created = rdr.GetNonNullableValue<DateTime>("created");
            modified = rdr.GetNullableStruct<DateTime>("modified");
            creatorName = $"{rdr.GetNonNullableValue<string>("last_name")}, {rdr.GetNonNullableValue<string>("first_name")} {rdr.GetNonNullableValue<string>("middle_name")}";
        }
    }
}
