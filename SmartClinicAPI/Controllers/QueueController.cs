using SmartClinic.Model.DC;
using SmartClinic.Model.Utilities;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class QueueController : ApiController
    {

        [Route("{DocID}")]
        [Route("Queue/GetQueue/{DocID}")]
        [HttpGet]
        public List<QueueDC> GetQueue(int DocID)
        {
            QueueFactory objQueue = new QueueFactory();
            return objQueue.GetQueue(DocID);

        }
    }
}
