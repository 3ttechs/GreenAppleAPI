/*
 * File Name   : SessionController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Session DB Table. 
 *               SPs used -> GetNextSlotNo, AddSession, GetSession, UpdateSession, DeleteSession
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
    public class SessionController : ApiController
    {
        [Route("{DocID}")]
        [Route("Session/GetSession/{DocID}")]
        [Route("GetSession/{DocID}")]
        [HttpGet]
        public List<SessionDC> GetSession(int DocID)
        {
            SessionFactory objSessionFactory = new SessionFactory();

            return objSessionFactory.GetSession(DocID);
        }

        [Route("Session/GetAllSession/{DocID}")]
        [Route("GetAllSession/{DocID}")]
        [HttpGet]
        public List<SessionDC> GetAllSession()
        {
            SessionFactory objSessionFactory = new SessionFactory();

            return objSessionFactory.GetSession(0);
        }

        [Route("Session/GetAllSessionMultyParameters/{DocID},{patName}")]
        [Route("GetAllSessionMultyParameters/{DocID},{patName}")]
        [HttpGet]
        public List<SessionDC> GetAllSessionMultyParameters(int DocID, string patName)
        {
            SessionFactory objSessionFactory = new SessionFactory();

            return objSessionFactory.GetSession(DocID);
        }

        [Route("Session/AddSession")]
        [ActionName("AddSession")]
        //tjv modified. Check with Chandra
        //[HttpPut]
        [HttpPost]
        public bool AddSession([FromBody] SessionDC objSessionDC)
        {
            //Note : objSessionDC.SessionStart, objSessionDC.SessionEnd are in GMT

            SessionFactory objSessionFactory = new SessionFactory();

            int sessionID = objSessionFactory.AddSession(objSessionDC);

            if (sessionID != -100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("Session/UpdateSession")]
        [ActionName("UpdateSession")]
        //[HttpPatch]
        [HttpPost]
        public bool UpdateSession([FromBody] SessionDC objSessionDC)
        {
            SessionFactory objSessionFactory = new SessionFactory();

            if (objSessionFactory.Factory(objSessionDC, "Update"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("Session/DeleteSession")]
        [ActionName("DeleteSession")]
        //[HttpDelete]
        [HttpPost]
        public bool DeleteSession([FromBody] SessionDC objSessionDC)
        {
            SessionFactory objSessionFactory = new SessionFactory();

            if (objSessionFactory.Factory(objSessionDC, "Delete"))
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
