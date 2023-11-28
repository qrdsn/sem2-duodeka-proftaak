using DuodekaModels.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Users
{
    public abstract class UserBase : IUser
    {
        protected int userId;
        protected string email;
        protected UserRole role;
        protected string firstName;
        protected string middleName;
        protected string lastName;

        #region IUser implementation

        public int UserId => userId;
        public string Email
        {
            get => email;
            set => email = value;
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

        public string FullName => $"{lastName}, {firstName} {middleName}";

        #endregion

        public UserBase(SqlDataReader rdr)
        {
            userId = rdr.GetNonNullableValue<int>("user_id");
            email = rdr.GetNonNullableValue<string>("email");
            firstName = rdr.GetNonNullableValue<string>("first_name");
            middleName = rdr.GetNullableValue<string>("middle_name");
            lastName = rdr.GetNonNullableValue<string>("last_name");
            role = (UserRole)rdr.GetNonNullableValue<int>("role");
        }
    }
}
