using DuodekaModels.Helpers;
using Microsoft.Data.SqlClient;


namespace DuodekaModels.Users
{
    public interface IUser
    {

        public int UserId { get; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }


        public static IUser InstantiateUser(SqlDataReader rdr)
        {
            UserRole userRole = (UserRole)rdr.GetNonNullableValue<int>("role");

            switch (userRole)
            {
                case UserRole.Administrator:
                    return new AdminModel(rdr);
                case UserRole.Employee:
                    return new EmployeeModel(rdr);
                case UserRole.Customer:
                    return new CustomerModel(rdr);
                default:
                    return null;
            }
        }

    }
}