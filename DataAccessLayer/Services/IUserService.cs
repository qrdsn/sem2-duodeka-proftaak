using DuodekaModels;
using DuodekaModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IUserService
    {
        public IUser GetUserInfo(int userId);
        public int CreateUser(UserRegisterModel userModel);
        public int EditUser(IUser user);
        public int DeleteUser(int userId);
        public IUser Login(string username, string password);
    }
}
