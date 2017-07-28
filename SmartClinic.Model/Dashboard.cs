using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartClinic.Model
{
    public class Dashboard : iRepository<DashboardDC>
    {
        public List<DashboardDC> GetObject(int id)
        {
            DataTable dtDashboard = null;
            List<DashboardDC> lstObjGetDashboardDC = null;
            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
               
                dtDashboard = objDAL.ExecuteDataTable("Dashboard", new DBParameter("@DocID", id), CommandType.StoredProcedure);

                lstObjGetDashboardDC = new List<DashboardDC>();
                foreach (DataRow drAU in dtDashboard.Rows)
                {
                    lstObjGetDashboardDC.Add(new DashboardDC
                    {
                        NumPatientsToday = Convert.ToInt32(drAU["NumPatientsToday"]),
                        NumPatientsBookedToday = Convert.ToInt32(drAU["NumPatientsBookedToday"]),
                        NumPatientsArrivedToday = Convert.ToInt32(drAU["NumPatientsArrivedToday"]),
                        NumPatientsConsultedToday = Convert.ToInt32(drAU["NumPatientsConsultedToday"]),       
                        NumSessionsToday = Convert.ToInt32(drAU["NumSessionsToday"]),
                        NumSessionsThisMonth = Convert.ToInt32(drAU["NumSessionsThisMonth"])
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjGetDashboardDC = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }
            return lstObjGetDashboardDC;
        }

        public bool AddSmartClinic(DashboardDC obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSmartClinic(DashboardDC obj)
        {
            throw new NotImplementedException();
        }

      public  bool DeleteSmartClinic(DashboardDC obj)
        {
            throw new NotImplementedException();
        }

       
    }
}
