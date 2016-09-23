using System.Linq;
using System.Web.Mvc;
using BadApples.Model;
using Microsoft.AspNet.Identity;

namespace FunctionLevelAccessControlApple.Base
{
    public class BaseController : Controller
    {
        public Northwind Db = new Northwind();

        public Employee CurrentEmployee
        {
            get
            {
                var userId = User?.Identity?.GetUserId();
                return userId != null ? Db.AspNetUsers.First(p => p.Id == userId).Employee : null;
            }
        }
    }
}