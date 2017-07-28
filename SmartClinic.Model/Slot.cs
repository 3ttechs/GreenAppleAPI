/*
 * File Name   : Slot.cs
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

using SmartClinic;
using SmartClinic.Model.DC;
using SmartClinic.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartClinic.Model
{
    public class Slot : iRepository<SlotDC>
    {
	
        public bool AddSmartClinic(SlotDC obj)
        {
            bool result = false;

            try
            {
                DBParameter SesID = new DBParameter("@SesID", obj.SesID);
                DBParameter DocID = new DBParameter("@DocID", obj.DocID);
                DBParameter PatID = new DBParameter("@PatID", obj.PatID);
                DBParameter SlotNO = new DBParameter("@SlotNO", obj.SlotNO);
                DBParameter BillNo = new DBParameter("@BillNo", obj.BillNo);
                DBParameter Amount = new DBParameter("@Amount", obj.Amount);
                DBParameter Status = new DBParameter("@Status", obj.Status);

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(SesID);
                paramCollection.Add(DocID);
                paramCollection.Add(PatID);
                paramCollection.Add(SlotNO);
                paramCollection.Add(BillNo);
                paramCollection.Add(Amount);
                paramCollection.Add(Status);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("AddSlot", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public int AddSmartClinicInt(SlotDC obj)
        {
            int newID = -100;

            try
            {
                DBParameter SesID = new DBParameter("@SesID", obj.SesID);
                DBParameter DocID = new DBParameter("@DocID", obj.DocID);
                DBParameter PatID = new DBParameter("@PatID", obj.PatID);
                DBParameter SlotNO = new DBParameter("@SlotNO", obj.SlotNO);
                DBParameter BillNo = new DBParameter("@BillNo", obj.BillNo);
                DBParameter Amount = new DBParameter("@Amount", obj.Amount);
                DBParameter Status = new DBParameter("@Status", obj.Status);

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(SesID);
                paramCollection.Add(DocID);
                paramCollection.Add(PatID);
                paramCollection.Add(SlotNO);
                paramCollection.Add(BillNo);
                paramCollection.Add(Amount);
                paramCollection.Add(Status);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                newID = Convert.ToInt32(objDAL.ExecuteScalar("AddSlot", paramCollection, CommandType.StoredProcedure));
                Console.WriteLine("newID  : " + newID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return newID;
        }

        public bool UpdateSmartClinic(SlotDC obj)
        {
            bool result = false;

            try
            { 
                DBParameter SloID = new DBParameter("@SloID", obj.SloID);
                DBParameter SesID = new DBParameter("@SesID", obj.SesID);
                DBParameter DocID = new DBParameter("@DocID", obj.DocID);
                DBParameter PatID = new DBParameter("@PatID", obj.PatID);
                DBParameter SlotNO = new DBParameter("@SlotNO", obj.SlotNO);
                DBParameter BillNo = new DBParameter("@BillNo", obj.BillNo);
                DBParameter Amount = new DBParameter("@Amount", obj.Amount);
                DBParameter Status = new DBParameter("@Status", obj.Status);

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(SloID);
                paramCollection.Add(SesID);
                paramCollection.Add(DocID);
                paramCollection.Add(PatID);
                paramCollection.Add(SlotNO);
                paramCollection.Add(BillNo);
                paramCollection.Add(Amount);
                paramCollection.Add(Status);

                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("UpdateSlot", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public bool DeleteSmartClinic(SlotDC obj)
        {
            bool result = false;

            try
            {
                DBParameter DID = new DBParameter("@SloID", obj.SloID);
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(DID);
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
                result = objDAL.ExecuteNonQuery("DeleteSlot", paramCollection, CommandType.StoredProcedure) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        public List<SlotDC> GetObject(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<SlotDC> GetObject(int sesID, int docID)
        {
            DataTable dtSlot = null;
            List<SlotDC> lstObjSlot = null;

            try
            {
                SmartClinic.DBHelper objDAL = new SmartClinic.DBHelper();
               
                if (sesID == 0)
                {
                    dtSlot = objDAL.ExecuteDataTable("GetPatientSlot");
                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();
                    paramCollection.Add(new DBParameter("@SesID", sesID));
                    paramCollection.Add(new DBParameter("@DocID", docID));

                    dtSlot = objDAL.ExecuteDataTable("GetPatientSlot", paramCollection, CommandType.StoredProcedure);
                }

                lstObjSlot = new List<SlotDC>();
                
                foreach (DataRow dr in dtSlot.Rows)
                {
                    lstObjSlot.Add(new SlotDC
                    {
                        PatID = Convert.ToInt32(dr["PatID"]),
                        UsrID = Convert.ToInt32(dr["UsrID"]),
                        PatName = Convert.ToString(dr["PatName"]),
                        PatShortName = Convert.ToString(dr["PatShortName"]),
                        GuardianName = Convert.ToString(dr["GuardianName"]),
                        Occupation = Convert.ToString(dr["Occupation"]),
                        GuardianOccupation = Convert.ToString(dr["GuardianOccupation"]),
                        DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                        Sex = Convert.ToInt16(dr["Sex"]),
                        UsrType = Convert.ToChar(dr["UsrType"]),
                        DocID = Convert.ToInt32(dr["DocID"]),
                        usrName = Convert.ToString(dr["usrName"]),
                        UsrPwd = Convert.ToString(dr["UsrPwd"]),
                        UsrAddress = Convert.ToString(dr["UsrAddress"]),
                        UsrPhone1 = Convert.ToString(dr["UsrPhone1"]),
                        UsrPhone2 = Convert.ToString(dr["UsrPhone2"]),
                        UsrEmail = Convert.ToString(dr["UsrEmail"]),
                        SloID = Convert.ToInt32(dr["SloID"]),
                        SlotNO = Convert.ToInt32(dr["SlotNO"]),
                        SesID = Convert.ToInt32(dr["SesID"]),
                        BillNo = Convert.ToString(dr["BillNo"]),
                        //Amount = Convert.ToDouble(dr["Amount"]),
                        Amount = 0, //tjv decide what to do
                        Status = Convert.ToString(dr["Status"])
                    });
                }
            }
            catch (Exception ex)
            {
                lstObjSlot = null;
                Console.WriteLine("Exception : " + ex.ToString());
            }
            finally
            {

            }

            return lstObjSlot;
        }
    }
}