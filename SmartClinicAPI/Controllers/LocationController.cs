/*
 * File Name   : LocationController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Location DB Table. SPs used -> GetLocation
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
    public class LocationController : ApiController
    {
        [Route("{UsrID}")]
        [Route("Location/GetLocation/{DocID}")]
        [Route("GetLocation/{DocID}")]
        [HttpGet]
        public List<LocationDC> GetLocation(int UsrID)
        {
            LocationFactory objLocation = new LocationFactory();
            return objLocation.GetLocation(UsrID);
        }

        [Route("Location/GetAllLocation/{DocID}")]
        [Route("GetAllLocation/{DocID}")]
        [HttpGet]
        public List<LocationDC> GetAllLocation(int DocID)
        {
            LocationFactory objLocation = new LocationFactory();

            List<LocationDC> theList = objLocation.GetLocation(DocID);

            return theList;
        }
    }
}