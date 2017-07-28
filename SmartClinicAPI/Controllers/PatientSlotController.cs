/*
 * File Name   : PatientSlotController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Slot DB Table. SPs used -> GetPatientSlotList
 * Created By  : Tony Jacob
 * Created On  : 10May2016
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
    public class PatientSlotController : ApiController
    {
        [Route("Slot/GetPatientSlotList/{PatID},{DocID}")]
        [HttpGet]
        public List<PatientSlotDC> GetPatientSlotList(int PatID, int DocID)
        {
            PatientSlotFactory objPatientSlotFactory = new PatientSlotFactory();
           
            List<PatientSlotDC> theList = objPatientSlotFactory.GetPatientSlotList(PatID, DocID);

            return theList;
        }
    }
}
