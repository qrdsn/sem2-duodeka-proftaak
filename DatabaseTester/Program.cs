using DataAccessLayer;
using DuodekaModels.Items;
using DuodekaModels.Users;

var db = new DatabaseContext();


/*int t = x.DeleteUser(9);

Console.WriteLine(t);*/

/*var r = x.GetItemsInDirectory("R://2/9");

Console.WriteLine($"file name: {r[2].Name} \ncreator name: {r[2].CreatorName} \ncreation date: {r[2].Created}");
*/

/*var y = x.GetItemsInDirectory("R://2/9");

y[2].Name = "a ties name";
y[2].Description = "new folder description";

var t = x.EditItem(y[2]);
*/











//Create User
/*db.CreateUser(new UserRegisterModel()
{
    Email = "string",
    Password = "weakpassword",
    ConfirmPassword = "weakpassword",
    FirstName = "John",
    LastName = "Doe",
    Role = UserRole.Administrator,
});*/



//Delete User
/*db.DeleteUser(14);*/



//Get User Info
/*var user = db.GetUserInfo(13);*/



//Edit User Admin 
// TODO: completely dysfunctional as the Iuser model doenst contain a field for password but i was thinking maybe it would make sense to add an update password model or something like that wait nvm that wouldn't make any sense
/*user.FirstName = "my updated first name";
user.LastName = "my updated last name";
user.Password = "something";

db.EditUser(user);*/



//Edit User Employee
// TODO wouldn't work for password..?



//Edit User Customer
// TODO wouldn't work for password..?



//Login
/*var user = db.Login("something@mail.com", "bestpasswordever");
if (user == null)
{
    Console.WriteLine("login completely failed u fucking miserable piece of shit");
}
else
{
    Console.WriteLine($"successfully logged in {user.FullName}");
}*/





// Insert Item File
/*var file = db.InsertItem(-1, new InsertItemModel
{
    CreatorId = 1,
    Name = "filename",
    Description = "filedesc",
    ItemType = ItemTypes.File,
    ExtensionType = "pdf",
    Size = 2000,
    FileHashName = "zyxcba"
}, -1);*/



// Insert Item Project
/*var proj = db.InsertItem(-1, new InsertItemModel
{
    CreatorId = 1,
    Name = "Another project",
    Description = "proj desc",
    ItemType = ItemTypes.Project,
}, -1);*/



// Insert Item Directory
/*var dir = db.InsertItem(-1, new InsertItemModel
{
    CreatorId = 1,
    Name = "some other direc",
    Description = "directory in proj 1 with id 2",
    ItemType = ItemTypes.Directory,
}, -1);*/



// Delete Item
/*db.DeleteItem(16);*/



// Get Items In Directory
/*var items = db.GetItemsInDirectory("R://2/9");*/



//Edit Item Project
/*var proj = db.GetItemsInDirectory("R://");

proj[1].Name = "Another project with edited name";
proj[1].Description = "project description";

var editedProj = db.EditItem(proj[1]);*/



//Edit Item Directory
/*items[2].Name = "this is the folders name";
items[2].Description = "this is the folder description";

var editedItem = db.EditItem(items[2]);*/



//Edit Item File
/*items[3].Name = "a new new file name";
items[3].Description = "a new new file description";

var editedItem = db.EditItem(items[3]);*/



//Get Tree View
var treeItems = db.GetTreeView(1);







Console.ReadKey();