using DuodekaModels.Users;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Items
{
    public class ProjectModel : ItemBase
    {
        public ProjectModel(SqlDataReader rdr) : base (rdr)
        {
        }

        public EmployeeModel[] GetEmployees()
        {
            throw new NotImplementedException();
        }

        public CustomerModel[] GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
