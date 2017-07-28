/*
 * File Name   : DoctorController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Doctor DB Table. 
 *               SPs used -> GetAllDoctors
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          12Sep2016     GetAllDoctors() added
 * */

using SmartClinic.Model.DC;
using SmartClinic.Model.Factory;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class DoctorController : ApiController
    {

		/*
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
		*/

		[Route("Doctor/GetAllDoctors")]
        [Route("GetAllDoctors")]
        [HttpGet]
        public List<DoctorDC> GetAllDoctors()
        {
            System.Console.WriteLine("tjv...Inside GetAllDoctors()");
            DoctorFactory objDoctorFactory = new DoctorFactory();

            List<DoctorDC> theList = objDoctorFactory.GetDoctorList();
            System.Console.WriteLine("tjv...theList.Count : " + theList.Count);

            if (theList.Count > 0)
                return theList;
            else
                return null;
        }

    }
}