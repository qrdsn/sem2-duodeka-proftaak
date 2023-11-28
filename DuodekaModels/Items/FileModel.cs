using DuodekaModels.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Items
{
    public class FileModel: ItemBase
    {
        private string extension;
        private string hashname;
        private int size;

        public string Extension { get => extension; }

        public string Hashname { get => hashname;}

        public int Size { 
            get => size;
            set => size = value;
        }

        public FileModel(SqlDataReader rdr) : base(rdr)
        {            
            extension = rdr.GetNonNullableValue<string>("extension_type");
            size = rdr.GetNonNullableValue<int>("size");
            hashname = rdr.GetNonNullableValue<string>("file_hash_name");
        }
    }
}
