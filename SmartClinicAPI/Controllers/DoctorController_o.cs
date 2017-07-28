using SmartClinic.Model.DC;
using SmartClinic.Model.Utilities;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class DoctorController : ApiController
    {

        [Route("{UsrID}")]
        [Route("Doctor/GetDoctor/{DocID}")]
        [Route("GetDoctor/{DocID}")]
        [HttpGet]
        public List<DoctorDC> GetDoctor(int UsrID)
        {
            DoctorFactory objDoctor = new DoctorFactory();
            return objDoctor.GetDoctor(UsrID);

        }

        [Route("Doctor/GetAllDoctor/{DocID}")]
        [Route("GetAllDoctor/{DocID}")]
        [HttpGet]
        public List<DoctorDC> GetAllDoctor()
        {
            DoctorFactory objDoctor = new DoctorFactory();
            return objDoctor.GetDoctor(0);

        }


    }
}