using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Users
{
    public class EditUserModel
    {
        public int userId;
        public string email;
        public string password;
        public UserRole role;
        public string firstName;
        public string middleName;
        public string lastName;
        public string company;
        public string position;

        public int UserId => userId;
        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public UserRole Role
        {
            get => role;
            set => role = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string MiddleName
        {
            get => middleName;
            set => middleName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string Company
        {
            get => company;
            set => company = value;
        }
        public string Position
        {
            get => position;
            set => position = value;
        }
    }
}
