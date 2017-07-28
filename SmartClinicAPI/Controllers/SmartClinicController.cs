using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class SmartClinicController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "Test1", "test2" };
        }
        public string Get(int id)
        {
            return "This is SimpleGet";
        }

    }
}
