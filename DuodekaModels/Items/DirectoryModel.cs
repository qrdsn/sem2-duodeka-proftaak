using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Items
{
    public class DirectoryModel : ItemBase
    {
        public DirectoryModel(SqlDataReader rdr) : base(rdr)
        {
        }
    }
}
