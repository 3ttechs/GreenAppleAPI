/*
 * File Name   : SlotController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on  DB Tables -> Slot, Patient, UserAdmin
 *               SPs used -> GetPatientSlotList, AddSlot, DeleteSlot, UpdateSlot
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
    public class SlotController : ApiController
    {
        [Route("{UsrID}")]
        [Route("Slot/GetSlot/{SlotID}")]
        [Route("GetSlot/{SlotID}")]
        [HttpGet]
        public List<SlotDC> GetSlot(int UsrID)
        {
            SlotFactory objSlotFactory = new SlotFactory();

            return objSlotFactory.GetSlot(UsrID);
        }

        [Route("Slot/GetAllSlot/{SlotID}")]
        [Route("GetAllSlot/{SlotID}")]
        [HttpGet]
        public List<SlotDC> GetAllSlot()
        {
            SlotFactory objSlotFactory = new SlotFactory();

            return objSlotFactory.GetSlot(0);
        }

        [Route("Slot/GetSlot/{SesID},{DocID}")]
        [HttpGet]
        public List<SlotDC> GetSlot(int SesID, int DocID)
        {
            SlotFactory objSlotFactory = new SlotFactory();

            return objSlotFactory.GetSlot(SesID, DocID);
        }

        //tjv strip off 2. Do later
        [Route("Slot/AddSlot2")]
        [ActionName("AddSlot")]
        [HttpPost]
        public bool AddSlot([FromBody] SlotDC objSlotDC)
        {
            SlotFactory objSlotFactory = new SlotFactory();
            SessionFactory objSessionFactory = new SessionFactory();

            bool getNextSlotNoResult = false;
            int nextSlotNo = objSessionFactory.GetNextSlotNo(objSlotDC.SesID);
            System.Console.WriteLine("...nextSlotNo : " + nextSlotNo);

            if (nextSlotNo < 1) //0 or -1
            {
                getNextSlotNoResult = false;
            }
            else
            {
                getNextSlotNoResult = true;
                objSlotDC.SlotNO = nextSlotNo;
            }

            bool slotAddResult = false;
            if (getNextSlotNoResult == true)
            {
                int slotID = objSlotFactory.AddSlot(objSlotDC);
                if (slotID != -100)
                {
                    slotAddResult = true;
                }
                else
                {
                    slotAddResult = false;
                }
            }

            bool result = false;
            if (slotAddResult == true)
            {
                result = objSessionFactory.UpdateSession(objSlotDC.SesID);
            }
            else
            {
                result = false;
            }

            return result;
        }

        [Route("Slot/UpdateSlot")]
        [ActionName("Slot/UpdateSlot")]


        [HttpPost]
        public bool UpdateSlot([FromBody] SlotDC objUADC)
        {
            SlotFactory objSlotFactory = new SlotFactory();

            if (objSlotFactory.Factory(objUADC, "Update"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("Slot/DeleteSlot")]
        [ActionName("Slot/DeleteSlot")]
        //[HttpDelete]        
		[HttpPost]
        public bool DeleteSlot([FromBody] SlotDC objSlotDC)
        {
            SlotFactory objSlotFactory = new SlotFactory();
            SessionFactory objSessionFactory = new SessionFactory();

            bool slotDeleteResult = false;
            if (objSlotFactory.Factory(objSlotDC, "Delete"))
            {
                slotDeleteResult = true;
            }
            else
            {
                slotDeleteResult = false;
            }

            bool result = false;
            if (slotDeleteResult == true)
            {
                SessionDC objSessionDC = new SessionDC{SesID = objSlotDC.SesID};

                result = objSessionFactory.UpdateSessionIncrementCounter(objSessionDC);
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}