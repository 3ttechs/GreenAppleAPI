/*
 * File Name   : Location.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Location DB Table. SPs used -> GetLocation
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *              Tony Jacob          1Jun2016      Cleanup
 * */
using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartClinic.Model
{
    public class Location : iRepository<LocationDC>
    {
        public bool AddSmartClinic(LocationDC obj)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateSmartClinic(LocationDC obj)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSmartClinic(LocationDC obj)
        {
            throw new System.NotImplementedException();
        }

        public List<LocationDC> GetObject(int id)
        {
            DataTable dtLocation = null;
            List<LocationDC> lstObjLocationDC = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                if (id == 0)
                {
                    dtLocation = objDAL.ExecuteDataTable("GetLocation");
                }
                else
                {
                    dtLocation = objDAL.ExecuteDataTable("GetLocation", new DBParameter("@DocID", id), CommandType.StoredProcedure);
                }

                lstObjLocationDC = new List<LocationDC>();
                foreach (DataRow drAU in dtLocation.Rows)
                {
                    lstObjLocationDC.Add(new LocationDC
                    {
                        LocID = Convert.ToInt32(drAU["LocID"]),
                        LocName = Convert.ToString(drAU["LocName"]),
                        LocAddress = Convert.ToString(drAU["LocAddress"]),
                        LocPhone1 = Convert.ToString(drAU["LocPhone1"]),
                        LocPhone2 = Convert.ToString(drAU["LocPhone2"]),
                        LocEmail = Convert.ToString(drAU["LocEmail"]),
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjLocationDC = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjLocationDC;
        }
    }
}