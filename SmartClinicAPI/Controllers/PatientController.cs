/*
 * File Name   : PatientController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. 
 *               SPs used -> AddPatient, GetPatient, UpdatePatient, DeletePatient
 * Created By  : 
 * Created On  : 
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
    public class PatientController : ApiController
    {
        [Route("{PatID}")]
        [Route("Patient/GetPatient/{PatID}")]
        [Route("GetPatient/{PatID}")]
        [HttpGet]
        public List<PatientDC> GetPatient(int PatID)
        {
            PatientFactory objPatientFactory = new PatientFactory();
            return objPatientFactory.GetPatient(PatID);
        }

        [Route("Patient/GetAllPatient/{PatID}")]
        [Route("GetAllPatient/{PatID}")]
        [HttpGet]
        public List<PatientDC> GetAllPatient()
        {
            PatientFactory objPatientFactory = new PatientFactory();
            return objPatientFactory.GetPatient(0);
        }

        [Route("Patient/GetAllPatientMultyParameters/{PatID},{patName}")]
        [Route("GetAllPatientMultyParameters/{PatID},{patName}")]
        [HttpGet]
        public List<PatientDC> GetAllPatientMultyParameters(int PatID,string patName)
        {
            PatientFactory objPatientFactory = new PatientFactory();
            return objPatientFactory.GetPatient(PatID);
        }

        [Route("Patient/AddPatient")]
        [ActionName("AddPatient")]
        [HttpPut]
        public bool AddPatient([FromBody] PatientDC objPatDC)
        {
            PatientFactory objPatientFactory = new PatientFactory();

            if (objPatientFactory.Factory(objPatDC, "Add"))
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        [Route("Patient/UpdatePatient")]
        [ActionName("UpdatePatient")]
        [HttpPatch]
        public bool UpdatePatient([FromBody] PatientDC objPatDC)
        {
            PatientFactory objPatientFactory = new PatientFactory();

            if(objPatientFactory.Factory(objPatDC, "Update"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("Patient/DeletePatient")]
        [ActionName("DeletePatient")]
        [HttpDelete]
        public bool DeletePatient([FromBody] PatientDC objPatDC)
        {
            PatientFactory objPatientFactory = new PatientFactory();
            if (objPatientFactory.Factory(objPatDC, "Delete"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
