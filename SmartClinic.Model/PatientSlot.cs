/*
 * File Name   : PatientSlot.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Slot DB Table. SPs used -> GetPatientSlotList
 * Created By  : Tony Jacob
 * Created On  : 10May2016
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
    public class PatientSlot : iRepository<PatientSlotDC>
    {
        public bool AddSmartClinic(PatientSlotDC obj)
        {
            return true;
        }

        public bool UpdateSmartClinic(PatientSlotDC obj)
        {
            return true;
        }

        public bool DeleteSmartClinic(PatientSlotDC obj)
        {
            return true;
        }

        public List<PatientSlotDC> GetObject(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<PatientSlotDC> GetObjects(int patID, int docID)
        {
            DataTable dtPatientSlot = null;
            List<PatientSlotDC> lstObjPatientSlot = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@PatID", patID));
                paramCollection.Add(new DBParameter("@DocID", docID));

                dtPatientSlot = objDAL.ExecuteDataTable("GetPatientSlotList", paramCollection, CommandType.StoredProcedure);
                
                lstObjPatientSlot = new List<PatientSlotDC>();

                foreach (DataRow dr in dtPatientSlot.Rows)
                {
                    lstObjPatientSlot.Add(new PatientSlotDC
                    {
                        SloID = Convert.ToInt32(dr["SloID"]),
                        SesID = Convert.ToInt32(dr["SesID"]),
                        DocID = Convert.ToInt32(dr["DocID"]),
                        PatID = Convert.ToInt32(dr["PatID"]),
                        SlotNO = Convert.ToInt32(dr["SlotNO"]),
                        BillNo = Convert.ToString(dr["BillNo"]),
                        Amount = 0, //tjv decide what to do
                        Status = Convert.ToString(dr["Status"]),
                        SessionStart = Convert.ToDateTime(dr["SessionStart"])
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjPatientSlot = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjPatientSlot;
        }
    }
}