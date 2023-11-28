using DuodekaBusiness.Containers;
using DuodekaModels.Items;
using Microsoft.AspNetCore.Mvc;

namespace Duodeka.Controllers
{
    public class ItemsController : Controller
    {
        [HttpPost]
        public ActionResult<IItem[]> FilesInDirectory(string path)
        {
            try
            {
                return new ItemContainer().GetItemsInFolder(path);
            }
            catch(NullReferenceException)
            {
                return Conflict("folder is empty");
            }
            catch (Exception)
            {
                return Conflict("something went wrong");
            }
            
        }
    }
}
