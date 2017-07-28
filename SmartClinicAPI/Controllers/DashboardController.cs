using SmartClinic.Model.DC;
using SmartClinic.Model.Factory;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class DashboardController : ApiController
    {
        [Route("Dashboard/GetDashboardParams/{DocID}")]
        [HttpGet]
        public List<DashboardDC> GetDashboardParams(int DocID)
        {
            DashboardFactory objDashboardFactory = new DashboardFactory();
            return objDashboardFactory.GetDashboard(DocID);
        }

        [Route("Dashboard/GetQueue/{DocID}")]
        [HttpGet]
        public List<DashboardDC> GetQueue(int DocID)
        {
            DashboardFactory objDashboardFactory = new DashboardFactory();
            return objDashboardFactory.GetDashboard(DocID);
        }
    }
}
