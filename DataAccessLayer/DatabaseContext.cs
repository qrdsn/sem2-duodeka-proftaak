using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Services;
using DuodekaModels;
using DuodekaModels.Items;
using DuodekaModels.Users;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class DatabaseContext : IUserService, IItemService
    {
        public readonly string ConnectionString = "Server=mssqlstud.fhict.local;Encrypt=no;Database=dbi489971_ddtest;User Id=dbi489971_ddtest;Password=literallythepassword;";

        #region IUserService implementation

        public int CreateUser(UserRegisterModel userModel)
        {
            string q = "INSERT INTO users (email, password, role, first_name, middle_name, last_name) VALUES (@email, @password, @role, @fname, @mname, @lname);";

            var parms = new Dictionary<string, object>
            {
                {"@email", userModel.Email},
                {"@password", userModel.Password},
                {"@role", userModel.Role},
                {"@fname", userModel.FirstName},
                {"@mname", userModel.MiddleName},
                {"@lname", userModel.LastName},
                {"@company", userModel.Company},
                {"@position", userModel.Position},
            };


            //string only if user is customer = "INSERT INTO customers (user_id, company, position) VALUES (@newlyCreatedUserId...?, @company, @position);";

            return ExecuteNonQuery(q, parms);
        }

/*        private int createUser(UserRegisterModel userModel)
        {
            if (userModel.Role == UserRole.Administrator || userModel.Role == UserRole.Employee)
            {
                return createUser(userModel);
            }
            else if (userModel.Role == UserRole.Employee)
            {
                return createUser(userModel);
            }
            else
            {
                throw new NotImplementedException();
            }
        }*/

        public int DeleteUser(int userId)
        {
            string q = "DELETE FROM users WHERE user_id = @uid";

            var parms = new Dictionary<string, object>
            {
                {"@uid", userId},
            };

            return ExecuteNonQuery(q, parms);
        }

        private int editAdmin(EditUserModel userModel)
        {
            string q = "UPDATE users SET email = @email, password = @password, role = @role, first_name = @fname, middle_name @mname, last_name = @lname " +
                "WHERE user_id = @uid";

            var parms = new Dictionary<string, object>
            {
                {"@email", userModel.Email},
                {"@password", userModel.Password},
                {"@role", userModel.Role},
                {"@fname", userModel.FirstName},
                {"@mname", userModel.MiddleName},
                {"@lname", userModel.LastName},
                {"@uid", userModel.UserId}
            };

            return ExecuteNonQuery(q, parms);
        }

        private int editEmployee(EditUserModel userModel)
        {
            string q = "UPDATE users SET email = @email, password = @password, role = @role, first_name = @fname, middle_name @mname, last_name = @lname " +
                "WHERE user_id = @uid";

            var parms = new Dictionary<string, object>
            {
                {"@email", userModel.Email},
                {"@password", userModel.Password},
                {"@role", userModel.Role},
                {"@fname", userModel.FirstName},
                {"@mname", userModel.MiddleName},
                {"@lname", userModel.LastName},
                {"@uid", userModel.UserId}
            };

            return ExecuteNonQuery(q, parms);
        }

        private int editCustomer(EditUserModel userModel)
        {
            string q = "BEGIN TRANSACTION " +
                "UPDATE users SET email = @email, password = @password, role = @role, first_name = @fname, middle_name @mname, last_name = @lname " +
                "WHERE user_id = @uid; " +
                "UPDATE customers SET company = @company, position = @position " +
                "WHERE user_id = @uid; " +
                "COMMIT";

            var parms = new Dictionary<string, object>
            {
                {"@email", userModel.Email},
                {"@password", userModel.Password},
                {"@role", userModel.Role},
                {"@fname", userModel.FirstName},
                {"@mname", userModel.MiddleName},
                {"@lname", userModel.LastName},
                {"@uid", userModel.UserId },
                {"@company", userModel.Company },
                {"@position", userModel.Position },
            };

            return ExecuteNonQuery(q, parms);
        }

        public int EditUser(IUser user)
        {
            if (user is AdminModel)
            {
                return editAdmin((EditUserModel)user);
            }
            else if (user is EmployeeModel)
            {
                return editEmployee((EditUserModel)user);
            }
            else if (user is CustomerModel)
            {
                return editCustomer((EditUserModel)user);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IUser GetUserInfo(int userId)
        {
            // what data to get
            string q = "SELECT u.user_id, u.role, u.email, u.first_name, u.middle_name, u.last_name, " +
                "c.company, c.position " +
                "FROM users AS u " +
                "LEFT JOIN customers AS c ON u.user_id = c.user_id " +
                "WHERE u.user_id = @uid;";

            var parms = new Dictionary<string, object>
            {
                {"@uid", userId}
            };

            // how to format the data for usage
            Func<SqlDataReader, IUser> mapping = rdr =>
            {
                rdr.Read();

                return IUser.InstantiateUser(rdr);
            };

            // executing the retrieval 
            return GetSingle(q, parms, mapping);
        }

        public IUser Login(string email, string password)
        {
            string q = "SELECT * FROM users WHERE password = @password AND email = @email";


            var parms = new Dictionary<string, object>
            {
                {"@password", password},
                {"@email", email}
            };

            // how to format the data for usage
            Func<SqlDataReader, IUser> mapping = rdr =>
            {
                rdr.Read();

                return IUser.InstantiateUser(rdr);
            };

            // executing the retrieval 
            return GetSingle(q, parms, mapping);
        }

        #endregion

        #region IItemService implementation

        private int createItem(InsertItemModel itemModel)
        {
            string q = "INSERT INTO items (creator_id, name, description, path, type) " +
                "VALUES (@cid, @name, @description, @path, @type);";

            var parms = new Dictionary<string, object>
            {
                {"@cid", itemModel.CreatorId},
                {"@name", itemModel.Name},
                {"@description", itemModel.Description},
                {"@path", itemModel.Path},
                {"@type", itemModel.ItemType},
            };

            return ExecuteNonQuery(q, parms);
        }

        private int uploadFile(object file, InsertItemModel itemModel)
        {
            string q = "BEGIN TRANSACTION " +
                "DECLARE @outputID int; " +
                "INSERT INTO items(creator_id, name, description, path, type) " +
                "VALUES(@cid, @name, @description, @path, @type); " +
                "SELECT @outputID = scope_identity(); " +
                "INSERT INTO files(item_id, extension_type, size, file_hash_name) " +
                "VALUES(@outputID, @exttype, @size, @fhn); " +
                "COMMIT";

            var parms = new Dictionary<string, object>
            {
                {"@cid", itemModel.CreatorId},
                {"@name", itemModel.Name},
                {"@description", itemModel.Description},
                {"@path", itemModel.Path},
                {"@type", itemModel.ItemType},
                {"@exttype", itemModel.ExtensionType},
                {"@size", itemModel.Size},
                {"@fhn", itemModel.FileHashName},

            };

            return ExecuteNonQuery(q, parms);
        }

        public int InsertItem(object file, InsertItemModel item, int parentItemId)
        {
            item.Path = generatePath();

            if (item.ItemType == ItemTypes.Project || item.ItemType == ItemTypes.Directory)
            {
                return createItem(item);
            }
            else if (item.ItemType == ItemTypes.File)
            {
                return uploadFile("possibly the file object", item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private string generatePath()
        {
            return $"R://{2}";
        }

        public int DeleteItem(int itemId)
        {
            string q = "UPDATE items SET availability = 0 WHERE item_id = @itemId";

            var parms = new Dictionary<string, object>
            {
                {"@itemId", itemId},
            };

            return ExecuteNonQuery(q, parms);
        }

        public int EditItem(IItem item)
        {
            item.Modified = DateTime.UtcNow;

            string q = "UPDATE items SET creator_id = @cid, name = @name, description = @description, path = @path, modified = @modified, availability = @availability " +
                "WHERE item_id = @iid";

            var parms = new Dictionary<string, object>
            {
                {"@cid", item.CreatorId},
                {"@name", item.Name},
                {"@description", item.Description},
                {"@path", item.Path},
                {"@modified", item.Modified},
                {"@availability", item.Availability},
                {"@iid", item.Id}
            };

            return ExecuteNonQuery(q, parms);
        }

        public IItem[] GetItemsInDirectory(string parentPath)
        {
            // what data to get
            string q = "SELECT i.item_id, i.creator_id, i.name, i.description, i.path, i.type, i.created, i.modified, i.availability, " +
                "f.extension_type, f.size, f.file_hash_name, " +
                "u.first_name, u.last_name, u.middle_name " +
                "FROM items AS i " +
                "LEFT JOIN files AS f ON i.item_id = f.item_id " +
                "INNER JOIN users AS u ON i.creator_id = u.user_id " +
                "WHERE i.path = @path;"; //Selects all useful item information from a specified path

            var parms = new Dictionary<string, object>
            {
                {"@path", parentPath}
            };

            // how to format the data for usage
            Func<SqlDataReader, IItem[]> mapping = rdr =>
            {
                List<IItem> output = new List<IItem>();

                while (rdr.Read())
                {
                    output.Add(IItem.CreateInstance(rdr));
                }

                return output.ToArray();
            };

            // executing the retrieval 
            return GetList(q, parms, mapping);
        }

        public TreeNodeModel[] GetTreeView(int userId)
        {
            // what data to get
            //string q = "BEGIN TRANSACTION " +
            //    "DECLARE @project_ids TABLE(all_user_project_ids INT); " +
            //    "INSERT INTO @project_ids(all_user_project_ids) " +
            //    "(SELECT item_id FROM items INNER JOIN contributors ON items.item_id = contributors.project_link_id WHERE type = 0 AND contributors.user_link_id = @userId AND availability = 1); " +
            //    "DECLARE @allUserProjects TABLE(all_user_projects_id INT); " +
            //    "INSERT INTO @allUserProjects(all_user_projects_id) SELECT project_link_id FROM contributors WHERE user_link_id = @userId; " +
            //    "DECLARE @allFolders TABLE(FItem_id INT, Fvalue INT); " +
            //    "INSERT INTO @allFolders(Fitem_id, Fvalue) " +
            //    "(SELECT item_id, value FROM items CROSS APPLY SplitStrings_Ordered(path, '/') WHERE type = 1 AND availability = 1 AND ordinal = 2); " +
            //    "DECLARE @folder_ids TABLE(all_user_folder_ids INT); INSERT INTO @folder_ids(all_user_folder_ids) " +
            //    "(SELECT FItem_id AS item_id FROM @allFolders AS allfolders INNER JOIN @allUserProjects allUsers ON allfolders.Fvalue = allUsers.all_user_projects_id); " +
            //    "DECLARE @all_user_items TABLE(uitem_id INT); INSERT INTO @all_user_items(uitem_id) " +
            //    "(SELECT * FROM @project_ids UNION SELECT * FROM @folder_ids); " +
            //    "SELECT item_id, name, path, type, availability, description, creator_id, created, modified, first_name, middle_name, last_name FROM items " +
            //    "LEFT JOIN users ON items.creator_id = users.user_id " +
            //    "INNER JOIN @all_user_items ON item_id = uitem_id; " +
            //    "COMMIT"; //selects all useful information from the projects of a single user, and every single folder within those projects

            string q = "SELECT * FROM items LEFT JOIN users ON items.creator_id = users.user_id LEFT JOIN files ON items.item_id = files.item_id";

            var parms = new Dictionary<string, object>
            {
                {"@userId", userId}
            };

            // how to format the data for usage
            Func<SqlDataReader, IItem[]> mapping = rdr =>
            {
                List<IItem> output = new List<IItem>();

                while (rdr.Read())
                {
                    output.Add(IItem.CreateInstance(rdr));
                }

                return output.ToArray();
            };

            // executing the retrieval 
            var itemList = GetList(q, parms, mapping);

            var a = new List<TreeNodeModel>();

            foreach (var item in itemList)
            {
                a.Add(new TreeNodeModel(item));
            }

            return CreateNodeStructure(a).ToArray();
        }

        static List<TreeNodeModel> CreateNodeStructure(List<TreeNodeModel> items)
        {
            var result = new List<TreeNodeModel>();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Item.Path == "R:/")
                {
                    result.Add(items[i]);
                    items.Remove(items[i]);
                    i--;
                }
            }

            foreach (var root in result)
            {
                AddAllChildren(root, items);
            }

            return result;
        }


        // recursief nodes toeeoegen aan juiste parent
        private static void AddAllChildren(TreeNodeModel node, List<TreeNodeModel> items)
        {
            // exit condition 1 (wanneer er geen nodes meer zijn algemeen)
            if (items == null || items.Count < 1)
                return;

            // loop over alle nog niet gekoppelded nodes
            for (int i = 0; i < items.Count; i++)
            {
                // wanneer een niet gekoppelde node de huidige node als parent moet hebben
                if (items[i].Item.Path == node.Item.Path + "/" + node.Item.Id)
                {
                    // voeg deze toe aan de parent
                    node.AddChild(items[i]);

                    // haal de gevonde childnode uit lijst met mogelijkheden
                    //items.Remove(items[i]);
                    //i--; // corrigeer index na verwijderen item uit lijst

                    // zoek naar alle kinderen voor de hudige node
                    AddAllChildren(node.Items[node.Items.Count - 1], items);

                }
            }

            // hier komen we alleen waneeer er geen nodes meer zijn die de huidige node als parent hebben
            // method returned void, dus hier houdt de functie op
        }

        #endregion

        protected int ExecuteNonQuery(string queryString, Dictionary<string, object> parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    con.Open();

                    // create parameters
                    foreach (var parm in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parm.Key, parm.Value ?? (object)DBNull.Value)); //insert/update dbnull if parm object is null
                    }


                    return cmd.ExecuteNonQuery();
                }
            }
        }

        protected T[] GetList<T>(string queryString, Dictionary<string, object> parameters, Func<SqlDataReader,T[]> mappingFunction) 
            where T : class
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    con.Open();

                    // create parameters
                    foreach(var parm in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parm.Key, parm.Value));
                    }

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        return mappingFunction.Invoke(rdr);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        protected T GetSingle<T>(string queryString, Dictionary<string, object> parameters, Func<SqlDataReader, T> mappingFunction) 
            where T : class
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    con.Open();

                    // create parameters
                    foreach (var parm in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parm.Key, parm.Value));
                    }

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        return mappingFunction.Invoke(rdr);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
