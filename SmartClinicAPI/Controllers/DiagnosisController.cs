/*
 * File Name   : DiagnosisController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Diagnosis DB Table. SPs used -> AddDiagnosis, GetDiagnosis, UpdateDiagnosis, DeleteDiagnosis
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016     Cleanup
 * */
using SmartClinic.Model.DC;
using SmartClinic.Model.Factory;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartClinicAPI.Controllers
{
    public class DiagnosisController : ApiController
    {
        [Route("Diagnosis/GetDiagnosis/{SlotID}")]
        [Route("GetDiagnosis/{SlotID}")]
        [HttpGet]
        public DiagnosisDC GetDiagnosis(int SlotID)
        {
            DiagnosisFactory objDiagnosisFactory = new DiagnosisFactory();

            List<DiagnosisDC> theList = objDiagnosisFactory.GetDiagnosis(SlotID);

            if (theList.Count > 0)
                return theList[0];
            else
                return null;
        }

        [Route("Diagnosis/GetAllDiagnosis/{SlotID}")]
        [Route("GetAllDiagnosis/{SlotID}")]
        [HttpGet]
        public List<DiagnosisDC> GetAllDiagnosis()
        {
            DiagnosisFactory objDiagnosisFactory = new DiagnosisFactory();
            return objDiagnosisFactory.GetDiagnosis(0);
        }

        [Route("Diagnosis/AddDiagnosis")]
        [ActionName("Diagnosis/AddDiagnosis")]
        //[HttpPut]
        [HttpPost]
        public bool AddDiagnosis([FromBody] DiagnosisDC objDiagnosisDC)
        {
            System.Console.WriteLine("tjv...Inside AddDiagnosis()...objDiagnosisDC.SloID : " + objDiagnosisDC.SloID);

            DiagnosisFactory objDiagnosisFactory = new DiagnosisFactory();
            if (objDiagnosisFactory.Factory(objDiagnosisDC, "Add"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("Diagnosis/UpdateDiagnosis2")]
        [ActionName("Diagnosis/UpdateDiagnosis2")]
        //[HttpPatch]
        //tjv modified. Check with Chandra
        [HttpPost]
        public bool UpdateDiagnosis2([FromBody] DiagnosisDC objDiagnosisDC)
        {
            DiagnosisFactory objDiagnosisFactory = new DiagnosisFactory();
            if (objDiagnosisFactory.Factory(objDiagnosisDC, "Update"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("Diagnosis/DeleteDiagnosis")]
        [ActionName("Diagnosis/DeleteDiagnosis")]
        [HttpDelete]
        public bool DeleteDiagnosis([FromBody] DiagnosisDC objUADC)
        {
            DiagnosisFactory objDiagnosisFactory = new DiagnosisFactory();
            if (objDiagnosisFactory.Factory(objUADC, "Delete"))
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