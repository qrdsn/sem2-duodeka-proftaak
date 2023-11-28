using DuodekaModels.Helpers;
using Microsoft.Data.SqlClient;

namespace DuodekaModels.Users
{
    public class CustomerModel : UserBase
    {

        protected string company;
        protected string position;

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

        public CustomerModel(SqlDataReader rdr) : base(rdr)
        {
            company = rdr.GetNonNullableValue<string>("company");
            position = rdr.GetNonNullableValue<string>("position");
        }
    }
}