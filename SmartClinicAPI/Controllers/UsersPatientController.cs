/*
 * File Name   : UsersPatientController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. SPs used -> GetPatientList, GetUserPatientList
 * Created By  : Tony Jacob
 * Created On  : 12May2016
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016      Cleanup
 * */

using SmartClinic.Model.DC;
using SmartClinic.Model.Factory;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class UsersPatientController : ApiController
    {
        [Route("Patient/GetUserPatientList/{UsrID},{DocID}")]
        [HttpGet]
        public List<UsersPatientDC> GetUserPatientList(int UsrID, int DocID)
        {
            UsersPatientFactory objUserPatientFactory = new UsersPatientFactory();

            List<UsersPatientDC> theList = objUserPatientFactory.GetUserPatientList(UsrID, DocID);

            return theList;
        }

        [Route("Patient/GetDoctorPatientList/{DocID}")]
        [HttpGet]
        public List<UsersPatientDC> GetDoctorPatientList(int DocID)
        {
            UsersPatientFactory objUserPatientFactory = new UsersPatientFactory();

            List<UsersPatientDC> theList = objUserPatientFactory.GetDoctorPatientList(DocID);

            return theList;
        }
    }
}

