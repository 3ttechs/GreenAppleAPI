/*
 * File Name   : LocationFactory.cs
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
using SmartClinic.Repository;
using System;
using System.Collections.Generic;

namespace SmartClinic.Model.Factory
{
    public class LocationFactory
    {
        iRepository<LocationDC> objLocation = new Location();

        public bool Factory(LocationDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        result = objLocation.AddSmartClinic(obj);
                        break;
                    case "Update":
                        result = objLocation.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objLocation.DeleteSmartClinic(obj);
                        break;
                    //case "Select":
                    //    List<LocationDC> objList = objLocation.GetObject(1);
                    //    break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public List<LocationDC> GetLocation(int DocID)
        {
            List<LocationDC> locations = null;

            try
            {
                locations = objLocation.GetObject(DocID);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return locations;
        }
    }
}
