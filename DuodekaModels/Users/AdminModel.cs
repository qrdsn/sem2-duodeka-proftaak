using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Users
{
    public class AdminModel : EmployeeModel
    {
        public AdminModel(SqlDataReader rdr) : base(rdr)
        {
        }

        public static int DeleteProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public static int CreateUser(UserRegisterModel userData)
        {
            throw new NotImplementedException();
        } 

        public static int EditUser(int userId)
        {
            throw new NotImplementedException();
        }

        public static int DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
