using DuodekaModels.Helpers;
using DuodekaModels.Items;
using Microsoft.Data.SqlClient;

namespace DuodekaModels.Users
{
    public class EmployeeModel : UserBase
    {
        public EmployeeModel(SqlDataReader rdr) : base(rdr)
        {
        }


        public static int CreateProject(string title, string description)
        {
/*            var db = new DatabaseContext();

            return db.CreateItem(-1, new InsertItemModel
            {
                CreatorId = 1,
                Name = title,
                Description = description,
                ItemType = ItemTypes.Project,
            });*/

            throw new NotImplementedException();
        }

        public static int EditProject(ProjectModel project)
        {
            throw new NotImplementedException();
        }

        public static int DeleteEmptyProject(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}