using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Model
{
    public class Queue : iRepository<QueueDC>
    {
        public List<QueueDC> GetObject(int id)
        {
            DataTable dtSession = null;
            List<QueueDC> lstObjGetQueueDC = null;
            try
            {
                using (SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper())
                {
                    if (id == 0)
                    {
                        dtSession = objDAL.ExecuteDataTable("Queue");
                    }
                    else
                    {
                        dtSession = objDAL.ExecuteDataTable("Queue", new DBParameter("@DocID", id), CommandType.StoredProcedure);
                    }
                }

                lstObjGetQueueDC = new List<QueueDC>();
                foreach (DataRow drAU in dtSession.Rows)
                {
                    lstObjGetQueueDC.Add(new QueueDC
                    {
                        SlotNO = Convert.ToInt32(drAU["SlotNO"]),
                        PatientsToday=Convert.ToString(drAU["PatientsToday"]),
                        Status = Convert.ToString(drAU["Status"])
                    });

                }
            }
            catch (Exception expMsg)
            {
                lstObjGetQueueDC = null;
            }
            finally
            {

            }
            return lstObjGetQueueDC;
        }

        public bool AddSmartClinic(QueueDC obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSmartClinic(QueueDC obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSmartClinic(QueueDC obj)
        {
            throw new NotImplementedException();
        }
    }
}
