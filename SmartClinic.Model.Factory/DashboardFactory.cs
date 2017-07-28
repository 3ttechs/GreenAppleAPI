using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartClinic.Repository;
using SmartClinic.Model.DC;
namespace SmartClinic.Model.Factory
{
    public class DashboardFactory
    {
        iRepository<DashboardDC> objDashboard = new Dashboard();

        public bool Factory(DashboardDC obj, string TypeOf)
        {
            bool result = false;

            try
            {
                switch (TypeOf)
                {
                    case "Add":
                        result = objDashboard.AddSmartClinic(obj);
                        break;
                    case "Update":
                        result = objDashboard.UpdateSmartClinic(obj);
                        break;
                    case "Delete":
                        result = objDashboard.DeleteSmartClinic(obj);
                        break;
                    // case "Select":
                    //    List<PatientDC> objList = ObjPatient.GetObject(1);
                    //     break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public List<DashboardDC> GetDashboard(int DocID)
        {
            List<DashboardDC> DashboardParamsList = null;

            try
            {
                DashboardParamsList = objDashboard.GetObject(DocID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return DashboardParamsList;
        }
    }
}
